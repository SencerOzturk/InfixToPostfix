using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infix_postfix_son_ders_kodları
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Infix'ten Postfix'e çeviren kod
            string postfix = "";
            string infix = "a+b*c/d-e*f";
            string op = "$+-*/()";
            int[] oncelik = { 0, 2, 2, 3, 3, 1, 1 };

            push("$");

            for (int i = 0; i < infix.Length; i++)
            {
                int indis = op.IndexOf(infix[i]); //infix stringinin icinde op stringinin icinde olanlardan varsa onun ındeksını dondurur.

                if (indis == -1)
                {
                    // Eğer karakter bir operatör değilse, doğrudan postfix'e ekle (yani harf gelmıs)
                    postfix = postfix + infix[i];
                    continue; //bir sonraki infix elemanına gec.
                }

                if (infix[i] == '(')
                {
                    push(infix[i].ToString()); //stacke push edıldı.
                    continue;
                }

                if (infix[i] == ')')
                {
                    while (peek() != "(") //en sondakı mevcut  stacktekı ıfade acma parantezı olana dek.
                    {
                        postfix = postfix + pop(); //acma parantezı gelene kadar stackı bosalt.Pop cıkarılan degerı gerı dondurur.Parantez ıcını bosalttık.
                    }
                    pop(); // '(' karakterini yığıttan çıkar
                    continue; //else yapısı kullanmak yerıne continue yapısı kullanılıyor.
                }

                // Operatörlerin önceliğine göre işlemler
                while (oncelik[indis] <= oncelik[op.IndexOf(peek()[0])]) //eger gelen operand stackte bulunan operanddan kucuk ya da esıtse  [0] kısmını yazsaydık "" ıcınde bır strıng dondururdu ama bu op strıngının ıcınde yok yanı char aramalıyız o yuzden [0] koyduk.
                {
                    postfix = postfix + pop(); //pop yap kucuk ve esıt operandları
                }

                push(infix[i].ToString()); //Eger gelen eleman parantez olmadan ve mevcut stacktekı elemanlardan oncelıklı ıse dırekt ekle.
            }

            while (stackcount() > 1) //cevırme ıslemı bıttıgınde (for dongusu bıtınce) stacktekı butun elemanlar postfıxe eklenır
            {
                postfix = postfix + pop();
            }

            Console.WriteLine("Postfix: " + postfix);
            Console.ReadKey();


        }

        // Stack fonksiyonları
        static string[] stack = new string[100];
        static int sp = -1;

        static void push(string data)
        {
            sp++;
            stack[sp] = data;
        }

        static string pop()
        {
            string data = stack[sp];
            sp--;
            return data;
        }

        static int stackcount()
        {
            return sp + 1;
        }

        static string peek() //stackte en son eklenen elemanı dondurur.
        {
            return stack[sp];
        }





  


    }


}