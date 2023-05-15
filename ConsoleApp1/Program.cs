///////////////////////////// Program   ////////////////////////////////
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAITAP_KETHUA
{
    class Program
    {
        static DANHSACHNHANVIEN danhsach;
        public static DataTable InitEmployee()
        {
            var table = new DataTable();
            try
            {

                Console.WriteLine(" Nhap tu 1-6 de thuc hien cac chuc nang sau:");
                Console.WriteLine("1. Nhap nhan vien");
                Console.WriteLine("2. Xuat nhan vien");
                Console.WriteLine("3. Tim nhan vien");
                Console.WriteLine("4. Xoa nhan vien");
                Console.WriteLine("5. Thong ke nhan vien");
                Console.WriteLine("6. tinh tong quy luong");
                int menu = 0;
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        {
                            danhsach.Nhap();
                            break;
                        }
                    case 2:
                        {
                            danhsach.Xuat();
                            break;
                        }
                    case 3:
                        {
                            danhsach.Tim().Xuat();
                            break;
                        }
                    case 4:
                        {
                            danhsach.Xoa();
                            break;
                        }
                    case 5:
                        {
                            danhsach.thongke();
                            break;
                        }
                    case 6:
                        {
                            danhsach.tinhTongQuyLuong();
                            break;
                        }
                    default:
                        Console.WriteLine("Yeu cau nhap chuc nang menu tu 1-6 ");
                        InitEmployee();
                        break;
                }// end switch
            }
            catch (Exception ex)
            {
                InitEmployee();
            }
            return table;
        }//end Menu


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var  data = InitEmployee();
            string[] columnNames = data.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();

            DataRow[] rows = data.Select();

            var table = new ConsoleTable(columnNames);
            foreach (DataRow row in rows)
            {
                table.AddRow(row.ItemArray);
            }
            table.Write(Format.MarkDown);
            table.Write(Format.Alternative);
            table.Write(Format.Minimal);
            table.Write(Format.Default);
            Console.Read();
            char c = 'y';
            while (c == 'y')
            {
            danhsach = new DANHSACHNHANVIEN();
                InitEmployee();
                Console.WriteLine("Nhap ky tu 'y' de tro ve menu");
                c = Convert.ToChar(Console.ReadLine().ToLower());
            }
        }

        
    }
}

