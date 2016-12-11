using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALGHOMEWORK2
{
    class Program
    {
        static string option;

        static void Main(string[] args)
        {
           
            Console.WriteLine("MENU\n1)\t Kesir girişi\n2)\tSonuç\n3)\tİşlemler\n4)\tÇıkış");
           
           
            int[] pay=new int[100]; int[] payda=new int[100];
           
            bool islemler = false;
            do
            {
                Console.Write("bir işlem secin:\t");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":

                        int dimension;
                        bool control = false;
                        do
                        {

                            Console.WriteLine("boyut girin");
                            try
                            {
                                dimension = Convert.ToInt32(Console.ReadLine());
                                control = true;
                                pay = new int[dimension];
                                payda = new int[dimension];
                                
                                int counter = 0;
                                string[] kesirSplit;
                                do
                                {
                                    try
                                    {
                                        Console.Write("{0} ıncı kesri 1/2 formatında  girin=", (counter + 1));
                                        string kesir = Console.ReadLine();

                                        kesirSplit = kesir.Split('/');

                                        pay[counter] = Convert.ToInt32(kesirSplit[0]);
                                        payda[counter] = Convert.ToInt32(kesirSplit[1]);

                                        counter++;
                                    }
                                    catch (Exception)
                                    {

                                        Console.WriteLine("gecersiz format");
                                    }

                                } while (counter < dimension);
                                counter = 0;
                               
                                break;
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("gecersiz giriş");
                            }
                        } while (!control);
                        break;
                    case "2":
                        result(pay, payda);
                        break;
                    case "3":
                        result(pay, payda);
                        break;
                    case "4":
                        islemler = true;
                        break;
                    default:
                        Console.WriteLine("gecersiz secenek");
                        break;

                }
            } while (!islemler);
           
        }
        public static void divide(ref int small, ref int big)
        {
            int counter = 2;
           
            while(true)
            {
                if (small % counter == 0 && big % counter == 0)
                {                   
                    small = small / counter;
                    big = big / counter;
                }
                else
                    counter++;
                if (small<=counter)
                    break;
                
            }
        }
        public static void result(int[]pay,int[] payda)
        {
            for (int i = 0; i < pay.Length; i++)
            {
                if (pay[i] == 1)
                    continue;
                for (int j = 0; j < payda.Length; j++)
                {
                    if (payda[j] == 1||pay[i]==1)
                        continue;
                    if(pay[i]<=payda[j])
                    {
                        if (payda[j] % pay[i] == 0)
                        {
                                             
                                Console.Write(pay[i] + "/" + payda[j] + "==>>");
                           
                            payda[j] = payda[j] / pay[i];
                            pay[i] = 1;
                            
                                Console.WriteLine(pay[i] + "/" + payda[j]);
                        }
                        else
                        {

                            int x = pay[i]; int y = payda[j];
                            divide(ref pay[i], ref payda[j]);
                            if ( x != pay[i] && y != payda[j])
                            {
                                Console.Write(x + "/" + y + "==>>");
                                Console.WriteLine(pay[i] + "/" + payda[j]);
                            }                      
                      }
                    }
                    else
                    {
                        if (pay[i] % payda[j] == 0)
                        {
                          
                                Console.Write(pay[i] + "/" + payda[j] + "==>>");
                           
                            pay[i] = pay[i] / payda[j];
                            payda[j] = 1;
                          
                                Console.WriteLine(pay[i] + "/" + payda[j]);
                        }
                        else
                        {
                            int x = pay[i];int y = payda[j];
                            divide(ref payda[j], ref pay[i]);
                            if ( x != pay[i] && y != payda[j])
                            {
                                Console.Write(x + "/" + y + "==>>");
                                Console.WriteLine(pay[i] + "/" + payda[j]);
                            }

                        }
                    }
                   
                }
            }
            int payResult = 1,paydaResult=1;
            for (int i = 0; i < pay.Length; i++)
            {
                //Console.WriteLine("{0}/{1}",pay[i],payda[i]);
                payResult = payResult * pay[i];
                paydaResult = paydaResult * payda[i];
            }
            Console.WriteLine("sonuc = {0}/{1}",payResult,paydaResult);
        }
      
    }
}
