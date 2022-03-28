﻿using System;
using System.Text;

namespace LudusCristal
{
    internal class Program  

    {
        static void Main(string[] args)
        {
            
            var  generator = new RandomGenerator();
            //Ganhos Totais
            var totalGanhos = generator.RandomNumber(5, 100);       
            Console.WriteLine("Total ganhos = " + totalGanhos);

            //Nmro de Jogadas
            var nmrJogadas = generator.RandomNumber(1,4);
            Console.WriteLine("Nmro jogadas = " + nmrJogadas);

            int totalRestante = totalGanhos;

            //array global com 10  posiçoes
            int[] jogadasRealizadas = new int[10];
            Array.Fill(jogadasRealizadas, -1);

            //digo o nmro de vezes que repito o ciclo com o nmro de jogadas
            //tenho que fazer moneytotal-jogada1 = j1; j1-jogada2 = j2; ...
            
            //Se o nmro de Jogadas for 1, o ganho tem de ser obrigatoriamente igual ao valor gerado
            if(nmrJogadas == 1)
            {
                jogadasRealizadas[0] = totalRestante;
                Console.WriteLine("Array[0] = " + jogadasRealizadas[0]);
            }
            else if (nmrJogadas == 2){
                int valorGerado = 0;
                
                //vai permitir que o primeiro nmro seja sempre do nivel 1
                if(totalGanhos <= 20)
                    {
                        valorGerado = generator.RandomNumber(1,(totalGanhos-1));
                    } 
                else
                    {
                        valorGerado = generator.RandomNumber(1,20);
                    }

                totalRestante -= valorGerado;

                if(totalRestante >= 21)
                {
                    jogadasRealizadas[0] = valorGerado;
                    jogadasRealizadas[1] = 0;
                    jogadasRealizadas[2] = totalRestante;

                    Console.WriteLine("Array[0] = " + jogadasRealizadas[0] + "\t Array[1] = " + jogadasRealizadas[1] + "\t Array[2] = " + jogadasRealizadas[2]);
                }
                else
                {
                    jogadasRealizadas[0] = valorGerado;
                    jogadasRealizadas[1] = totalRestante;

                    Console.WriteLine("Array[0] = " + jogadasRealizadas[0] + "\t Array[1] = " + jogadasRealizadas[1]);
                }
            }
            else
            {
                int valorGerado1 = 0;
                int valorGerado2 = 0;
                //vai permitir que o primeiro nmro seja sempre do nivel 1
                if(totalGanhos <= 20)
                {
                    valorGerado1 = generator.RandomNumber(1,(totalGanhos-1));
                } 
                else
                {
                    valorGerado1 = generator.RandomNumber(1,20);
                }

                totalRestante -= valorGerado1;

                if(totalRestante <= 20)
                {
                    valorGerado2 = generator.RandomNumber(1,(totalRestante-1));
                }
                else
                {
                    valorGerado2 = generator.RandomNumber(1,20);
                }

                totalRestante -= valorGerado2;


                if(totalRestante >= 21)
                {
                    jogadasRealizadas[0] = valorGerado1;
                    jogadasRealizadas[1] = valorGerado2;
                    jogadasRealizadas[2] = 0;
                    jogadasRealizadas[3] = totalRestante;

                    Console.WriteLine("Array[0] = " + jogadasRealizadas[0] + "\t Array[1] = " + jogadasRealizadas[1] + "\t Array[2] = " + jogadasRealizadas[2] + "\t Array[3] = " + jogadasRealizadas[3]);
                }
                else
                {
                    jogadasRealizadas[0] = valorGerado1;
                    jogadasRealizadas[1] = valorGerado2;
                    jogadasRealizadas[2] = totalRestante;

                    Console.WriteLine("Array[0] = " + jogadasRealizadas[0] + "\t Array[1] = " + jogadasRealizadas[1] + "\t Array[2] = " + jogadasRealizadas[2]);
                }
            }
        }
    }
    public class RandomGenerator{
        
        private readonly Random _random = new Random();  

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }

}