/*
* ==============================
* FileName:		FacadePatternSimple1
* Author:		DuanBin
* CreateTime:	8/13/2018 4:27:12 PM
* Description:		
* ==============================
*/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

/**
 *某软件公司欲开发一个可应用于多个软件的文件加密模块，该模块可以对文件中的
 *数据进行加密并将加密之后的数据存储在一个新文件中，具体的流程包括三个部
 *分，分别是读取源文件、加密、保存加密之后的文件，其中，读取文件和保存文件
 *使用流来实现，加密操作通过求模运算实现。这三个操作相对独立，为了实现代码
 *的独立重用，让设计更符合单一职责原则，这三个操作的业务代码封装在三个不同
 *的类中。 现使用外观模式设计该文件加密模块。
 */
namespace FacadePatternSimple1
{
	public class FacadePatternSimple1 : MonoBehaviour {
	
		void Start () {
			
		}
	}

    /// <summary>
    /// 文件读取类，充当子系统类
    /// </summary>
    public class FileReader
    {
        public string Read(string fileNameSrc)
        {
            Debug.Log("读取文件，获取明文");
            FileStream fs = null;
            StringBuilder sb = new StringBuilder();
            try
            {
                fs = new FileStream(fileNameSrc, FileMode.Open);
                int data;
                while ((data = fs.ReadByte()) != -1)
                {
                    sb = sb.Append((char)data);
                }
                fs.Close();
                Debug.Log(sb.ToString());
            }
            catch (FileNotFoundException e)
            {
                Debug.Log(e.Message);
            }
            catch (IOException e)
            {
                Debug.Log(e.Message);
            }
            return sb.ToString();
        }
    }

    /// <summary>
    /// 数据加密类，充当子系统类
    /// </summary>
    public class CipherMachine
    {
        public string Encrypt(string plainText)
        {
            Debug.Log("数据加密，将明文转换为密码文 : ");
            string res = null;
            char[] chars = plainText.ToCharArray();
            foreach (char item in chars)
            {
                string c = (item % 7).ToString();
                res += c;
            }
            Debug.Log("数据加密后 ：" + res);
            return res;
        }
    }

    /// <summary>
    /// 文件保存类，充当子系统类
    /// </summary>
    public class FileWriter
    {
        public void Writer(string encryptStr,string fileNameDes)
        {
            Debug.Log("保存密文，写入文件");
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileNameDes, FileMode.Create);
                byte[] str = Encoding.Default.GetBytes(encryptStr);
                fs.Write(str, 0, str.Length);
                fs.Flush();
                fs.Close();
            }
            catch (FileNotFoundException e)
            {
                Debug.Log(e.Message);
            }
            catch(IOException e)
            {
                Debug.Log(e.Message);
            }
        }
    }

    /// <summary>
    /// 加密外观类，充当外观类
    /// </summary>
    public class EncryptFacade
    {
        // 维持对其他对象的引用
        private FileReader _reader;
        private CipherMachine _cipher;
        private FileWriter _writer;

        public EncryptFacade()
        {
            _reader = new FileReader();
            _cipher = new CipherMachine();
            _writer = new FileWriter();
        }

        public void FileEncrypt(string fileNameSrc,string fileNameDes)
        {
            string plainStr = _reader.Read(fileNameSrc);
            string encryptStr = _cipher.Encrypt(plainStr);
            _writer.Writer(encryptStr, fileNameDes);
        }
    }
}


