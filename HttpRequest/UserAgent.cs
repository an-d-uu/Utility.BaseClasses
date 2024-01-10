using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.BaseClasses.HttpRequest
{
    /// <summary>
    /// The static HttpRequest.UserAgent class is used to correctly format the UserAgent string that is sent in the request header of web service calls. It simplifies the process so all you need to do is call the Get() method.The static HttpRequest.UserAgent class is used to correctly format the UserAgent string that is sent in the request header of web service calls. It simplifies the process so all you need to do is call the Get() method.
    /// </summary>
    public static class UserAgent
    {
        private static string UserAgentString { get; set; } = string.Empty;
        private static string Name { get; set; } = string.Empty;
        private static string Version { get; set; } = string.Empty;

        /// <summary>
        /// ShowErrors flag allows you to toggle on and off the displaying of errors in the HttpRequest.UserAgent methods. Useful when you are building a console application and you plan to check if the value is set rather than dealing with the error stopping the process and triggering your exception handling call.
        /// </summary>
        public static bool ShowErrors { get; set; } = true;

        /// <summary>
        /// Simple method to return the UserAgent string.
        /// </summary>
        /// <returns>{Name}/{Version} i.e. "Utility.BaseClasses/1.0"</returns>
        public static string Get()
        {
            return Get(string.Empty);
        }
        /// <summary>
        /// Method to return the UserAgent, Name, or Version values. By default it will return 'UserAgent'.
        /// </summary>
        /// <param name="value2Return">Name, Version, or UserAgent (Default: 'UserAgent')</param>
        /// <returns>{Name}/{Version} i.e. "Utility.BaseClasses/1.0"</returns>
        public static string Get(string value2Return = "")
        {
            string value = string.Empty;
            try
            {
                switch (value2Return.ToLower())
                {
                    case "name":
                        if (!(string.IsNullOrEmpty(Name)))
                            value = Name;
                        else
                        {
                            SetUserAgentValues();
                            value = Name;
                        }
                        break;
                    case "version":
                        if (!(string.IsNullOrEmpty(Version)))
                            value = Version;
                        else
                        {
                            SetUserAgentValues();
                            value = Version;
                        }
                        break;
                    default:
                        if (!(string.IsNullOrEmpty(UserAgentString)))
                            value = UserAgentString;
                        else
                        {
                            SetUserAgentValues();
                            value = UserAgentString;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ShowErrors)
                    throw ex;
            }

            return value;
        }

        private static void SetUserAgentValues()
        {
            if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Version))
                Set(string.Empty, string.Empty);
            else if (string.IsNullOrEmpty(Name) && (!(string.IsNullOrEmpty(Version))))
                Set(string.Empty, Version);
            else if (!(string.IsNullOrEmpty(Name)) && (string.IsNullOrEmpty(Version)))
                Set(Name, string.Empty);
            else if (string.IsNullOrEmpty(Name) && (!(string.IsNullOrEmpty(Version))))
                Set(Name, string.Empty);
            else if (!(string.IsNullOrEmpty(Name)) && !(string.IsNullOrEmpty(Version)) && string.IsNullOrEmpty(UserAgentString))
                Set(Name, Version);
        }
        /// <summary>
        /// The Set method allows you to set the Name of the application and Version for the UserAgent if you don't like or the returned derrived values are not what you would like them to be.
        /// </summary>
        /// <param name="appName">Assembly Name of the application.</param>
        /// <param name="appVersion">Version of the application in x.x or x.x.x format.</param>
        public static void Set(string appName, string appVersion)
        {
            try
            {

                if (string.IsNullOrEmpty(appName) || string.IsNullOrEmpty(appVersion))
                {
                    string assemblyLocation = GetAssemblyLocation();
                    string productVersion = string.Empty;
                    if (System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation).ProductBuildPart == 0)
                        productVersion = string.Format("{0}.{1}", System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation).ProductMajorPart
                                                                       , System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation).ProductMinorPart);
                    else
                        productVersion = string.Format("{0}.{1}.{2}", System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation).ProductMajorPart
                                                               , System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation).ProductMinorPart
                                                               , System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation).ProductBuildPart);

                    appName = GetAssemblyName();
                    appVersion = productVersion ?? "0.0.0";
                }
            }
            catch (Exception ex)
            {
                if (ShowErrors)
                    throw ex;
                else
                {
                    appName = "Unknown";
                    appVersion = "0.0";
                }
            }
            Name = appName;
            Version = appVersion;
            UserAgentString = string.Format("{0}/{1}", appName, appVersion);
        }
        private static string GetAssemblyLocation()
        {
            string location = string.Empty;

            //try to get it from the System.Reflection.Assembly.GetExecutingAssembly().Location
            location = GetAssemblyLocation("GetExecutingAssembly");

            if (string.IsNullOrEmpty(location))
                location = GetAssemblyLocation("GetEntryAssembly");

            if (string.IsNullOrEmpty(location))
                location = GetAssemblyLocation("GetCallingAssembly");

            return location;
        }
        private static string GetAssemblyLocation(string method2use)
        {
            try
            {
                switch (method2use.ToLower())
                {
                    case "getexecutingassembly":
                        return System.Reflection.Assembly.GetExecutingAssembly().Location;
                    case "getentryassembly":
                        return System.Reflection.Assembly.GetEntryAssembly().Location;
                    default:
                    case "getcallingassembly":
                        return System.Reflection.Assembly.GetCallingAssembly().Location;
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        private static string GetAssemblyName()
        {
            string name = string.Empty;

            name = GetAssemblyName("GetEntryAssembly");

            if (string.IsNullOrEmpty(name))
                name = GetAssemblyName("GetCallingAssembly");

            if (string.IsNullOrEmpty(name))
                name = GetAssemblyName("GetExecutingAssembly");

            return name;
        }
        private static string GetAssemblyName(string method2use)
        {
            try
            {
                switch (method2use.ToLower())
                {
                    case "getexecutingassembly":
                        return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                    case "getentryassembly":
                        return System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
                    default:
                    case "getcallingassembly":
                        return System.Reflection.Assembly.GetCallingAssembly().GetName().Name;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}

