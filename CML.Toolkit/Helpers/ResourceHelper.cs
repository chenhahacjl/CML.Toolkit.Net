using System.Reflection;
using System.Text;

namespace CML.Toolkit.Helpers
{
    /// <summary>
    /// 资源帮助类
    /// </summary>
    public static class ResourceHelper
    {
        /// <summary>
        /// 资源是否存在
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <param name="resource">资源路径</param>
        /// <returns>资源存在状态</returns>
        public static bool ExistResource(this Assembly assembly, string resource)
        {
            return assembly.GetManifestResourceNames().Contains(resource);
        }

        /// <summary>
        /// 获取资源流
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <param name="resource">资源路径</param>
        /// <returns>资源流</returns>
        /// <exception cref="FileNotFoundException">未找到资源异常</exception>
        public static Stream? GetResourceStream(this Assembly assembly, string resource)
        {
            if (assembly.ExistResource(resource))
            {
                return assembly.GetManifestResourceStream(resource);
            }
            else
            {
                throw new FileNotFoundException(resource);
            }
        }
        /// <summary>
        /// 获取资源数据
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <param name="resource">资源路径</param>
        /// <returns>资源数据</returns>
        /// <exception cref="FileNotFoundException">未找到资源异常</exception>
        public static byte[] GetResourceData(this Assembly assembly, string resource)
        {
            using Stream? stream = assembly.GetManifestResourceStream(resource);
            using MemoryStream memoryStream = new();

            stream?.CopyTo(memoryStream);

            return memoryStream.ToArray() ?? Array.Empty<byte>();
        }

        /// <summary>
        /// 获取资源文本（UTF-8）
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <param name="resource">资源路径</param>
        /// <returns>资源文本</returns>
        /// <exception cref="FileNotFoundException">未找到资源异常</exception>
        public static string GetResourceString(this Assembly assembly, string resource)
        {
            return GetResourceString(assembly, resource, Encoding.UTF8);
        }

        /// <summary>
        /// 获取资源文本
        /// </summary>
        /// <param name="assembly">程序集</param>
        /// <param name="resource">资源路径</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>资源文本</returns>
        /// <exception cref="FileNotFoundException">未找到资源异常</exception>
        public static string GetResourceString(this Assembly assembly, string resource, Encoding encoding)
        {
            using Stream? stream = assembly.GetManifestResourceStream(resource);
            if (stream == null) { return string.Empty; }

            using StreamReader streamReader = new(stream, encoding);

            return streamReader.ReadToEnd();
        }
    }
}
