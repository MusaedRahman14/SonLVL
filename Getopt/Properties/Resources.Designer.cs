﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GetoptNET.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GetoptNET.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: option &apos;&apos;{1}&apos;&apos; is ambiguous.
        /// </summary>
        internal static string getoptAmbigious {
            get {
                return ResourceManager.GetString("getoptAmbigious", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: option &apos;&apos;--{1}&apos;&apos; doesn&apos;t allow an argument.
        /// </summary>
        internal static string getoptArguments1 {
            get {
                return ResourceManager.GetString("getoptArguments1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: option &apos;&apos;{1}{2}&apos;&apos; doesn&apos;t allow an argument.
        /// </summary>
        internal static string getoptArguments2 {
            get {
                return ResourceManager.GetString("getoptArguments2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: illegal option -- {1}.
        /// </summary>
        internal static string getoptIllegal {
            get {
                return ResourceManager.GetString("getoptIllegal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: invalid option -- {1}.
        /// </summary>
        internal static string getoptInvalid {
            get {
                return ResourceManager.GetString("getoptInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid value {0} for parameter &apos;has_arg&apos; .
        /// </summary>
        internal static string getoptInvalidValue {
            get {
                return ResourceManager.GetString("getoptInvalidValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: option &apos;&apos;{1}&apos;&apos; requires an argument.
        /// </summary>
        internal static string getoptRequires {
            get {
                return ResourceManager.GetString("getoptRequires", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: option requires an argument -- {1}.
        /// </summary>
        internal static string getoptRequires2 {
            get {
                return ResourceManager.GetString("getoptRequires2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: unrecognized option &apos;&apos;--{1}&apos;&apos;.
        /// </summary>
        internal static string getoptUnrecognized {
            get {
                return ResourceManager.GetString("getoptUnrecognized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}: unrecognized option &apos;&apos;{1}{2}&apos;&apos;.
        /// </summary>
        internal static string getoptUnrecognized2 {
            get {
                return ResourceManager.GetString("getoptUnrecognized2", resourceCulture);
            }
        }
    }
}
