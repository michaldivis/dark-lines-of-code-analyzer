﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DarkLinesOfCode {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DarkLinesOfCode.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to A class should contain an average of less than 30 methods, resulting in up to 900 lines of code.
        /// </summary>
        internal static string DL0100Description {
            get {
                return ResourceManager.GetString("DL0100Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The class &apos;{0}&apos; contains {1} lines of code, maximum recommended amount of lines per class is {2} lines.
        /// </summary>
        internal static string DL0100Message {
            get {
                return ResourceManager.GetString("DL0100Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The class contains too many lines of code.
        /// </summary>
        internal static string DL0100Title {
            get {
                return ResourceManager.GetString("DL0100Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Methods should not have more than an average of 30 code lines (not counting line spaces and comments).
        /// </summary>
        internal static string DL0200Description {
            get {
                return ResourceManager.GetString("DL0200Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The method &apos;{0}&apos; contains {1} lines of code, maximum recommended amount of lines per method is {2} lines.
        /// </summary>
        internal static string DL0200Message {
            get {
                return ResourceManager.GetString("DL0200Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The method contains too many lines of code.
        /// </summary>
        internal static string DL0200Title {
            get {
                return ResourceManager.GetString("DL0200Title", resourceCulture);
            }
        }
    }
}