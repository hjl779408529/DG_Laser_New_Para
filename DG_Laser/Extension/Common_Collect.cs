using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DG_Laser
{
    class Common_Collect
    {
        /// <summary>
        /// 序列化保存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="txtFile"></param>
        public static void Serialize<T>(List<T> list, string txtFile)
        {
            //写入文件
            string File_Path = @"./\Config/" + txtFile;
            using (FileStream fs = new FileStream(File_Path, FileMode.Create, FileAccess.ReadWrite))
            {
                //保存为xml
                XmlSerializer bf = new XmlSerializer(typeof(List<T>));
                bf.Serialize(fs, list);
            }
        }
        /// <summary>
        /// 反序列化读取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<T> Reserialize<T>(string File_Path)
        {

            //读取文件
            using (FileStream fs = new FileStream(File_Path, FileMode.Open, FileAccess.Read))
            {
                //xml 反序列化
                XmlSerializer bf = new XmlSerializer(typeof(List<T>));
                List<T> list = (List<T>)bf.Deserialize(fs);
                return list;
            }
        }

        /// <summary>
        /// list转datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static DataTable ListToDt<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }
        /// <summary>
        /// 反射和泛型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class DtToList<T> where T : new()
        {
            /// <summary>
            /// datatable转list
            /// </summary>
            /// <param name="dt"></param>
            /// <returns></returns>
            public static List<T> ConvertToModel(DataTable dt)
            {

                List<T> ts = new List<T>();// 定义集合
                Type type = typeof(T); // 获得此模型的类型
                string tempName = null;
                foreach (DataRow dr in dt.Rows)
                {
                    T t = new T();
                    PropertyInfo[] propertys = t.GetType().GetProperties();// 获得此模型的公共属性
                    foreach (var a in propertys) 
                    {
                        tempName = a.Name;
                        if (dt.Columns.Contains(tempName))
                        {
                            if (!a.CanWrite) continue;
                            object value = dr[tempName];
                            if (value != DBNull.Value)
                            {
                                if (!a.PropertyType.IsGenericType)
                                {
                                    //非泛型
                                    a.SetValue(t, string.IsNullOrEmpty(value.ToString()) ? null : Convert.ChangeType(value, a.PropertyType), null);
                                }
                                else
                                {
                                    //泛型Nullable<>
                                    Type genericTypeDefinition = a.PropertyType.GetGenericTypeDefinition();
                                    if (genericTypeDefinition == typeof(Nullable<>))
                                    {
                                        a.SetValue(t, string.IsNullOrEmpty(value.ToString()) ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(a.PropertyType)), null);
                                    }
                                }
                            }
                        } 
                    }
                    ts.Add(t);
                }
                return ts;
            }
        }
        /// <summary>
        /// DtToXml
        /// </summary>
        /// <param name="xmlDS"></param>
        /// <returns></returns>
        private string ConvertDataTableToXML(DataTable xmlDS)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.Default);
                xmlDS.WriteXml(writer);
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                UTF8Encoding utf = new UTF8Encoding();
                return utf.GetString(arr).Trim();
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }
        /// <summary>
        /// XmlToDt
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        private DataSet ConvertXMLToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);
                reader = new XmlTextReader(stream);
                xmlDS.ReadXml(reader);
                return xmlDS;
            }
            catch (Exception ex)
            {
                string strTest = ex.Message;
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        
    }
}
