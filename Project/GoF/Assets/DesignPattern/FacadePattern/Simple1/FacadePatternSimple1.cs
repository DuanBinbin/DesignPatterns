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
 *ĳ�����˾������һ����Ӧ���ڶ��������ļ�����ģ�飬��ģ����Զ��ļ��е�
 *���ݽ��м��ܲ�������֮������ݴ洢��һ�����ļ��У���������̰���������
 *�֣��ֱ��Ƕ�ȡԴ�ļ������ܡ��������֮����ļ������У���ȡ�ļ��ͱ����ļ�
 *ʹ������ʵ�֣����ܲ���ͨ����ģ����ʵ�֡�������������Զ�����Ϊ��ʵ�ִ���
 *�Ķ������ã�����Ƹ����ϵ�һְ��ԭ��������������ҵ������װ��������ͬ
 *�����С� ��ʹ�����ģʽ��Ƹ��ļ�����ģ�顣
 */
namespace FacadePatternSimple1
{
	public class FacadePatternSimple1 : MonoBehaviour {
	
		void Start () {
			
		}
	}

    /// <summary>
    /// �ļ���ȡ�࣬�䵱��ϵͳ��
    /// </summary>
    public class FileReader
    {
        public string Read(string fileNameSrc)
        {
            Debug.Log("��ȡ�ļ�����ȡ����");
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
    /// ���ݼ����࣬�䵱��ϵͳ��
    /// </summary>
    public class CipherMachine
    {
        public string Encrypt(string plainText)
        {
            Debug.Log("���ݼ��ܣ�������ת��Ϊ������ : ");
            string res = null;
            char[] chars = plainText.ToCharArray();
            foreach (char item in chars)
            {
                string c = (item % 7).ToString();
                res += c;
            }
            Debug.Log("���ݼ��ܺ� ��" + res);
            return res;
        }
    }

    /// <summary>
    /// �ļ������࣬�䵱��ϵͳ��
    /// </summary>
    public class FileWriter
    {
        public void Writer(string encryptStr,string fileNameDes)
        {
            Debug.Log("�������ģ�д���ļ�");
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
    /// ��������࣬�䵱�����
    /// </summary>
    public class EncryptFacade
    {
        // ά�ֶ��������������
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


