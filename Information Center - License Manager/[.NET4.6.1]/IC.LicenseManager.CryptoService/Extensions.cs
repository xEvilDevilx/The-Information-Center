using System.Collections.Generic;

namespace IC.LicenseManager.CryptoService
{
    /// <summary>
    /// Presents Extensions functionality
    /// 
    /// 2017/08/27 - Created, VTyagunov
    /// </summary>
    public class Extensions
    {
        #region Methods

        /// <summary>
        /// Use for check Array Equal
        /// </summary>
        /// <typeparam name="T">Array type</typeparam>
        /// <param name="a1">First Array</param>
        /// <param name="a2">Second Array</param>
        /// <returns></returns>
        public static bool ArraysEqual<T>(T[] a1, T[] a2)
        {
            if (ReferenceEquals(a1, a2))
                return true;

            if (a1 == null || a2 == null)
                return false;

            if (a1.Length != a2.Length)
                return false;

            var comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < a1.Length; i++)
            {
                if (!comparer.Equals(a1[i], a2[i])) return false;
            }
            return true;
        }

        #endregion
    }
}