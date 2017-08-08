using System.ComponentModel;
namespace System
{
    public static class DesignerClass
    {
        #region DesignMode
        /// <summary>
        /// Programın Dizayn Modunda mı yoksa Çalışma Modundamı olduğunu belirtir.
        /// Usercontroller 'de Initialize zamanında oluşan ilk değer atama hatalarında kullanılabilir.
        /// </summary>
        /// <returns:true>Dizayn Mod</returns>
        /// <returns:false>Çalışma Mod</returns>
        public static bool DesignMode()
        {
            return System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpperInvariant().Contains("devenv".ToUpperInvariant());
        }

        /// <summary>
        /// Programın Dizayn Modunda mı yoksa Çalışma Modundamı olduğunu belirtir
        /// </summary>
        /// <returns:true>Dizayn Mod</returns>
        /// <returns:false>Çalışma Mod</returns>
        public static bool DesignModeOnComponent()
        {
            return (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
        }
        #endregion
    }
}