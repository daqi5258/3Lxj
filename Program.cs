using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace _3Lxj
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /*
            String path1 = @"\\Hcdata\和创施工图设计平台\公建一所\";
            String path2 = @"\\Hcdata\和创施工图设计平台\公建二所\";
            String path3 = @"\\Hcdata\和创施工图设计平台\居住一所\";
            String path4 = @"\\Hcdata\和创施工图设计平台\居住二所\";

            BoTree<String> fileTree = new BoTree<string>();
            getFile(path1,"", @"E:\公建一所");
            Console.WriteLine("path1 finished");
            getFile(path2, "", @"E:\公建二所");
            Console.WriteLine("path2 finished");
            getFile(path3, "", @"E:\居住一所");
            Console.WriteLine("path3 finished");
            getFile(path4, "", @"E:\居住二所");
            Console.WriteLine("path4 finished");
            */


            BoTree<String> tree1 = new BoTree<string>();
            /*
            getFolder(@"\\Hcdata\和创施工图设计平台\", "公建一所", ref tree1);
            getFolder(@"\\Hcdata\和创施工图设计平台\", "公建二所", ref tree1);
            getFolder(@"\\Hcdata\和创施工图设计平台\", "居住一所", ref tree1);
            getFolder(@"\\Hcdata\和创施工图设计平台\", "居住二所", ref tree1);
            */
            Thread[] t = new Thread[4];
            t[0] = new Thread(()=>getFolder(@"\\Hcdata\和创施工图设计平台\", "公建一所", ref tree1));
            t[1] = new Thread(() => getFolder(@"\\Hcdata\和创施工图设计平台\", "公建二所", ref tree1));
            t[2] = new Thread(() => getFolder(@"\\Hcdata\和创施工图设计平台\", "居住一所", ref tree1));
            t[3] = new Thread(() => getFolder(@"\\Hcdata\和创施工图设计平台\", "居住二所", ref tree1));
            foreach (Thread item in t)
            {
                item.Start();
            }
            foreach (Thread item in t)
            {
                item.Join();
            } 
            Console.WriteLine("输入回车结束！");
            Console.ReadLine();
        }


        public static void getFolder(String path, String filter, ref BoTree<String> fileTree)
        {
            Console.WriteLine("filter=" + filter +",path="+path);
            if (filter == "20*")
            {
                String[] dirs1 = Directory.GetDirectories(path, filter);
                
                foreach (String tmp in dirs1)
                {
                    BoTree<String> tmpTree = new BoTree<String>();
                    tmpTree.Data = tmp.ToString();
                    getFolder(tmp, "项师*", ref tmpTree);
                    fileTree.AddNode(tmpTree);
                }
            }
            else if (filter == "项师*")
            {
                string[] files1 = Directory.GetFiles(path, "*打分表.xlsx", SearchOption.AllDirectories);
                System.IO.File.WriteAllLines(@"E:\" + path.Split("\\")[4] + "_" + path.Split("\\")[5] + "评分表信息.txt", files1);
                //Console.WriteLine("path="+path+ @"E:\" + path.Split("\\")[4]);
                /*
                foreach (String tmp in files1)
                {
                    BoTree<String> tmpTree = new BoTree<String>();
                    tmpTree.Data = tmp.ToString();
                    fileTree.AddNode(tmpTree);
                }
                */
            }else 
            {
                String[] dirs1 = Directory.GetDirectories(path, filter);
               // Console.WriteLine("filter=" + filter + ",size=" + dirs1.Length);
                foreach (String tmp in dirs1)
                {
                    BoTree<String> tmpTree = new BoTree<String>();
                    tmpTree.Data = tmp.ToString();
                    getFolder(tmp, "20*", ref tmpTree);
                    fileTree.AddNode(tmpTree);
                }
            }
        }
        public static void getFile(String path, String filter,String filepath)
        {
            Console.WriteLine("2");
            string[] files1 = Directory.GetFiles(path, "*打分表.xlsx", SearchOption.AllDirectories);
            Console.WriteLine("file:"+ @"" + filepath + "评分表信息.txt");
            System.IO.File.WriteAllLines(@""+ filepath + "评分表信息.txt", files1);
            Console.WriteLine("2");
        }

        /*
        public static object[,] GetExcelRangeData(string excelPath, string stCell, string edCell)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Workbook workBook = null;
            object oMissiong = Missing.Value;
            try
            {
                workBook = app.Workbooks.Open(excelPath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                if (workBook == null)
                    return null;

                Worksheet workSheet = (Worksheet)workBook.Worksheets.Item[1];
                //使用下述语句可以从头读取到最后，按需使用
                //var maxN = workSheet.Range[startCell].End[XlDirection.xlDown].Row;
                return workSheet.Range[stCell + ":" + edCell].Value2;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                //COM组件方式调用完记得释放资源
                if (workBook != null)
                {
                    workBook.Close(false, oMissiong, oMissiong);
                    Marshal.ReleaseComObject(workBook);
                    app.Workbooks.Close();
                    app.Quit();
                    Marshal.ReleaseComObject(app);
                }
            }
        }

        //随便写的一个调用案例
        public static List<Edge> ReadAllEdgesFromFile()
        {
            List<Edge> lstEdges = new List<Edge>();
            object[,] data = ExcelHelper.GetExcelRangeData(FilePath, "A1", "C82412");
            int length = data.GetLength(0);
            //注意这里是从1开始的，调试的时候才发现
            for (int i = 1; i <= length; i++)
            {
                Edge edge = new Edge();
                //注意这里是从1开始的，调试的时候才发现
                edge.EdgeID = Convert.ToInt32(data[i, 1]);
                edge.EdgeStartIndex = Convert.ToInt32(data[i, 2]);
                edge.EdgeEndIndex = Convert.ToInt32(data[i, 3]);
                edge.StSelected = false;
                edge.EdSelected = false;

                lstEdges.Add(edge);
            }

            return lstEdges;
        }
        */
    }
}
