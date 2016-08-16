﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using SonicRetro.SonLVL.API;

namespace SonicRetro.SonLVL.API.SPA
{
	public class Object : ObjectLayoutFormat
	{
		public System.Drawing.Size LayoutSize;
		
		public override Type ObjectType { get { return typeof(SPAObjectEntry); } }

		public override List<ObjectEntry> ReadLayout(byte[] rawdata, out bool terminator)
		{
			List<ObjectEntry> objs = new List<ObjectEntry>();
			// ob = Object Block, oba = Object Block Address, oa = Object Address
			int oaBase, oba, oa;
			int obWidth, obHeight;

			terminator = false;
			obWidth = rawdata[0];
			obHeight = rawdata[1];
			LayoutSize.Width = obWidth * 192;
			LayoutSize.Height = obHeight * 192;
			oaBase = oba = 2;
			for (int oby = 0; oby < obHeight; oby ++)
				for (int obx = 0; obx < obWidth; obx ++)
				{
					oa = ByteConverter.ToUInt16(rawdata, oba);
					oba += 2;
					if (oa == 0)
						continue;
					oa += oaBase;
					//int oIdxStart = rawdata[oa + 0];
					int oCount = rawdata[oa + 1];
					oa += 2;
					for (int i = 0; i < oCount; i++, oa += SPAObjectEntry.Size)
						objs.Add(new SPAObjectEntry(rawdata, oa));
				}
			return objs;
		}

		public override byte[] WriteLayout(List<ObjectEntry> objects, bool terminator)
		{
			List<byte> tmp = new List<byte>();
			// ob = Object Block, oba = Object Block Address, oa = Object Address
			ushort oaBase, oba;
			int obWidth, obHeight;
			List<SPAObjectEntry>[,] obLUT;
			byte oIdxStart;

			obWidth = (LayoutSize.Width + 96) / 192;
			obHeight = (LayoutSize.Height + 96) / 192;
			// create Object Block table (sorts all objects into "activity blocks" of 192x192)
			obLUT = new List<SPAObjectEntry>[obWidth, obHeight];
			for (int oby = 0; oby < obHeight; oby++)
				for (int obx = 0; obx < obWidth; obx++)
					obLUT[obx, oby] = new List<SPAObjectEntry>();
			for (int i = 0; i < objects.Count; i++)
			{
				int obx = objects[i].X / 192;
				int oby = ((SPAObjectEntry)objects[i]).internalY / 192;
				if (obx < obWidth && oby >= 0)
					obLUT[obx, oby].Add((SPAObjectEntry)objects[i]);
			}
			// write Object Block Pointer Table
			tmp.Add((byte)obWidth);
			tmp.Add((byte)obHeight);
			oaBase = oba = (ushort)(obWidth * obHeight * 2);
			for (int oby = 0; oby < obHeight; oby ++)
				for (int obx = 0; obx < obWidth; obx ++)
				{
					if (obLUT[obx, oby].Count == 0)
					{
						tmp.AddRange(ByteConverter.GetBytes((ushort)0));
					}
					else
					{
						tmp.AddRange(ByteConverter.GetBytes(oba));
						oba += (ushort)(2 + SPAObjectEntry.Size * obLUT[obx, oby].Count);
					}
				}
			// write Object Blocks themselves
			oIdxStart = 0;
			for (int oby = 0; oby < obHeight; oby ++)
				for (int obx = 0; obx < obWidth; obx ++)
				{
					if (obLUT[obx, oby].Count > 0)
					{
						tmp.Add(oIdxStart);
						tmp.Add((byte)obLUT[obx, oby].Count);
						//obLUT[obx, oby].Sort();
						for (int i = 0; i < obLUT[obx, oby].Count; i++)
							tmp.AddRange(obLUT[obx, oby][i].GetBytes());
						oIdxStart += (byte)obLUT[obx, oby].Count;
					}
				}
			return tmp.ToArray();
		}
	}

	[DefaultProperty("ID")]
	[Serializable]
	public class SPAObjectEntry : ObjectEntry//, IComparable<SPAObjectEntry>	// TODO: with or without IComparable?
	{
		/*public override string _ID
		{
			get
			{
				return ID.ToString("X2");
			}
			set
			{
				ID = byte.Parse(value, System.Globalization.NumberStyles.HexNumber);
			}
		}

		public override byte ID
		{
			get
			{
				return base.ID;
			}
			set
			{
				base.ID = (byte)(value & 0x7F);
			}
		}*/

		public ushort internalY
		{
			// Actually the formula is (LevelHeigh - 1 - value),
			// but this causes the grid to go wrong.
			// So I make up for the -1 in the object code.
			get
			{
				return (ushort)(LevelData.FGHeight * 32 - Y);
			}
			set
			{
				Y = (ushort)(LevelData.FGHeight * 32 - value);
			}
		}
		
		public bool Difficulty { get; set; }
		
		public byte Param1 { get; set; }
		public byte Param2 { get; set; }
		public byte Param3 { get; set; }
		
		public static int Size { get { return 10; } }

		public SPAObjectEntry() { pos = new Position(this); isLoaded = true; }

		public SPAObjectEntry(byte[] file, int address)
		{
			byte[] bytes = new byte[Size];
			Array.Copy(file, address, bytes, 0, Size);
			FromBytes(bytes);
			pos = new Position(this);
			isLoaded = true;
		}

		public override byte[] GetBytes()
		{
			List<byte> ret = new List<byte>();
			ret.Add(ID);
			ret.Add(Difficulty ? (byte)1 : (byte)0);
			ret.AddRange(ByteConverter.GetBytes(X));
			ret.AddRange(ByteConverter.GetBytes(internalY));
			ret.Add(SubType);
			ret.Add(Param1);
			ret.Add(Param2);
			ret.Add(Param3);
			return ret.ToArray();
		}

		public override void FromBytes(byte[] bytes)
		{
			ID = bytes[0];
			if (bytes[1] > 1)
				throw new System.ArgumentException("Found object with invalid Difficulty type!", "SPAObjectEntry");
			Difficulty = (bytes[1] == 1);
			X = ByteConverter.ToUInt16(bytes, 2);
			internalY = ByteConverter.ToUInt16(bytes, 4);
			SubType = bytes[6];
			Param1 = bytes[7];
			Param2 = bytes[8];
			Param3 = bytes[9];
		}

		/*int IComparable<SPAObjectEntry>.CompareTo(SPAObjectEntry other)
		{
			int c = ID.CompareTo(other.ID);
			if (c == 0) c = X.CompareTo(other.X);
			if (c == 0) c = internalY.CompareTo(other.internalY);
			return c;
		}*/
	}
}
