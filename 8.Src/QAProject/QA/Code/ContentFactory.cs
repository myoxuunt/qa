using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;
using QA.Interface;

namespace QA
{
    public class ContentFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        static private bool IsImplementInterface(Type targetType, Type interfaceType)
        {
            Type[] types = targetType.GetInterfaces();
            foreach (Type t in types)
            {
                if (t == interfaceType)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static public IContent[] Create(string path)
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.LoadFrom(path);
            }
            catch (BadImageFormatException badEx)
            {
                ProcessException(badEx);
                return null;
            }

            //List<IContent> r = new List<IContent>();
            OrderNumberCollection<IContent> r = new OrderNumberCollection<IContent>();

            foreach (Type tp in assembly.GetTypes())
            {
                if (IsImplementInterface(tp, typeof(IContent)))
                {
                    IContent c = (IContent)Activator.CreateInstance(tp);
                    //return c;
                    r.Add(c);
                }
            }

            if (r.Count == 0)
            {
                string msg = string.Format("Create fail from '{0}'", path);
                ProcessException(msg);
                //return null;
            }
            r.Sort();

            IContent[] array = new IContent[r.Count];
            r.CopyTo(array, 0);
            return array;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        static private void ProcessException(Exception ex)
        {
            ProcessException(ex.Message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        static private void ProcessException(string msg)
        {
            NUnit.UiKit.UserMessage.DisplayFailure(msg);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="msg"></param>
        //static private void ThrowCreateException(string msg)
        //{
        //    InvalidOperationException ex = new InvalidOperationException(msg);
        //    throw ex;
        //}
    }
}
