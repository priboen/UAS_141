using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_141
{
    class Node
    {
        public int idBarang;
        public string namaBarang;
        public string jenisBarang;
        public int hargaBarang;
        public Node next;
    }
    class listBarang
    {
        Node START;
        public listBarang()
        {
            START = null;
        }
        public void inputBarang()
        {
            int idBrg, hBrg;
            string namaBrg, jenisBrg;

            Console.Write("Masukan ID Barang    : ");
            idBrg = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukan Nama Barang  : ");
            namaBrg = Console.ReadLine();
            Console.Write("Masukan Jenis Barang : ");
            jenisBrg = Console.ReadLine();
            Console.Write("Masukan Harga Barang : ");
            hBrg = Convert.ToInt32(Console.ReadLine());

            Node newnode = new Node();

            newnode.idBarang = idBrg;
            newnode.namaBarang = namaBrg;
            newnode.jenisBarang = jenisBrg;
            newnode.hargaBarang = hBrg;

            if (START == null || idBrg <= START.idBarang)
            {
                if ((START != null) && (idBrg == START.idBarang))
                {
                    Console.WriteLine("\nID ini sudah digunakan!\nSilahkan input ID lain!");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (idBrg >= current.idBarang))
            {
                if (idBrg == current.idBarang)
                {
                    Console.WriteLine("\nID ini sudah digunakan!\nSilahkan input ID lain!");
                    return;
                }
                previous = current;
                current = current.next;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public void cariBarang()
        {
            Node previous, current;
            current = previous = START;
            Console.Write("\nMasukan jenis barang yang ingin anda cari : ");
            string jb = Console.ReadLine();
            if (jb != current.jenisBarang)
            {
                Console.WriteLine("Jenis barang yang kamu inginkan belum ada.");
            }
            else
                Console.WriteLine("Menampilkan list yang kamu inginkan : ");
            Console.WriteLine("\n=================================================");
            while (current != null)
            {
                if (jb == current.jenisBarang)
                {
                    Console.WriteLine("\nID Barang      : " + current.idBarang);
                    Console.WriteLine("\nNama Barang    : " + current.namaBarang);
                    Console.WriteLine("\nJenis Barang   : " + current.jenisBarang);
                    Console.WriteLine("\nHarga Barang   : " + current.hargaBarang);
                    Console.WriteLine("\n=================================================");
                }
                current = current.next;
            }
        }
        public bool listKosong()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void traverses()
        {
            if (listKosong())
            {
                Console.WriteLine("\nJenis barang yang kamu inginkan belum ada.");
                Console.WriteLine("Tekan 'Enter' untuk melanjutkan.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nMenampilkan list yang kamu inginkan : ");
                Console.WriteLine("\n=================================================");
                Console.Write("ID Barang" + "   " + "Nama Barang" + "    " + "     " + "Jenis Barang" + "   " + "Harga Barang" + "\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                {
                    Console.Write(currentNode.idBarang + "    " + currentNode.namaBarang + "    " + currentNode.jenisBarang + "     " + currentNode.hargaBarang + "\n");
                }
                Console.WriteLine();
                Console.WriteLine("Tekan 'Enter' untuk melanjutkan.");
                Console.ReadKey();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            listBarang lb = new listBarang();
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("========================================================");
                    Console.WriteLine("              Toko Elektroni Haji Komar                 ");
                    Console.WriteLine("            Silahkan Plih Menu Dibawah ini              ");
                    Console.WriteLine("========================================================");
                    Console.WriteLine("1. Menambah barang");
                    Console.WriteLine("2. Menampilkan list barang");
                    Console.WriteLine("3. Cari berdasarkan jenis barang");
                    Console.WriteLine("4. Keluar");
                    Console.WriteLine("========================================================");
                    Console.Write("Masukan opsi yang anda inginkan (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                Console.Clear();
                                lb.inputBarang();
                            }
                            break;
                        case '2':
                            {
                                Console.Clear();
                                lb.traverses();
                            }
                            break;
                        case '3':
                            {
                                Console.Clear();
                                if (lb.listKosong() == true)
                                {
                                    Console.WriteLine("\nJenis barang yang kamu inginkan belum ada.");
                                    break;
                                }
                                else
                                    lb.cariBarang();
                                Console.WriteLine("");
                                Console.WriteLine("Press Enter to Continue");
                                Console.ReadLine();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Pilihan anda salah!\nSilahkan tekan 'Enter'." );
                                Console.ReadLine();
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Masukan angka yang sesuai dengan pilihan!");
                    Console.WriteLine("Silahkan tekan 'Enter' untuk kembali.");
                    Console.ReadLine();
                }
            }
        }
    }
}

//2. Single Linked List, karena input barang dilakukan secara bertahap dan lebih mudah untuk menggunakan single linked list
//3. Rear dan Front
//4. (a) banyak kedalaman yang dimiliki adalah 5.
//   (b) In Order : 1. Data dibaca dari posisi sebelah kiri
//                  2. Kemudian data dibaca di akarnya
//                  3. Data dibaca pindah ke sebelah kanan
//      dalam kasus ini urutan datanya adalah :
//      (15, 20, 25, 30, 31, 32, 35, 48, 50, 65, 66, 67, 69, 70, 90, 94, 98, 99)
//
//
//
