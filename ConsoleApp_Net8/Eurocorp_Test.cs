using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Net8
{
    public static class Eurocorp_test
    {

       
        /*         
             * 
             * [1:12 PM] Douglas Rocha
                    candidatos = [  
                    { nome: "Betina", habilidades: ['react', 'java', 'vue']},  
                    { nome: "Alberto", habilidades: ['react', 'vue', 'java'] },  
                    { nome: "Carlos", habilidades: ['java']},  
                    ]  
  
                    habilidades = [  
                      { nome: 'react', pontos: 10 },  
                      { nome: 'java', pontos: 5 },  
                      { nome: 'vue', pontos: 1 },  
                    ]
                    [1:12 PM] Douglas Rocha
                    [  
                      { nome: 'Alberto', pontos: 16 },  
                      { nome: 'Betina', pontos: 16 },  
                      { nome: "Carlos", pontos: 5 },  
                    ]
             * */
        /// <summary>
        /// Obtiene la suma de los puntos de cada habilidad de cada candidato, y obtiene la suma de las habilidades ordernando del candidato que tenga mas habilidades
        /// </summary>
        public static void ObtieneAgrupaCandidatos()
        {
            List<Candidato> candidatoList = new List<Candidato>()
              {
                new Candidato()
                {
                  name = "Betina",
                  habilidadList=new List<string>()
                  {
                    "react", "java", "vue"
                  }
                },
                new Candidato()
                {
                  name="Alberto",
                  habilidadList=new List<string>()
                  {
                    "react", "vue", "java"
                  }
                },
                new Candidato()
                {
                  name="Carlos",
                  habilidadList=new List<string>()
                  {
                    "c#", "java"
                  }
                }
              };


            List<Habilidad> habilidadInputList = new List<Habilidad>()
      {
        new Habilidad()
        {
          name="react",
          punto=10
        },
        new Habilidad()
        {
          name="java",
          punto=5
        },
        new Habilidad()
        {
          name="vue",
          punto=2
        },
        new Habilidad()
        {
          name="c#",
          punto=15
        }
      };

            List<OutPut> output = Ordena(candidatoList, habilidadInputList);

            foreach (var item in output)
            {
                Console.WriteLine($"item[{item.name}] sum ${item.punto}");
            }

        }

        /// <summary>
                /// Obtiene la suma de los puntos de cada habilidad de cada candidato, y obtiene la suma de las habilidades ordernando del candidato que tenga mas habilidades
                /// </summary>
                /// <param name="candidatoList"></param>
                /// <param name="habilidadInputList"></param>
                /// <returns></returns>
        private static List<OutPut> Ordena(List<Candidato> candidatoList, List<Habilidad> habilidadInputList)
        {
            List<OutPut> list = new List<OutPut>();

            foreach (var candidato in candidatoList)
            {
                List<OutPut> habilidadesGroup = (from lista in candidato.habilidadList
                                                 join hab in habilidadInputList on lista equals hab.name
                                                 group hab by new { hab.name, hab.punto } into g
                                                 select new OutPut
                                                 {
                                                     name = g.Key.name,
                                                     punto = g.Key.punto,
                                                 }).ToList();

                int habSum = habilidadesGroup.Sum(x => x.punto);

                if (!list.Where(x => x.name.Equals(candidato.name)).Any())
                {
                    list.Add(new OutPut
                    {
                        name = candidato.name,
                        punto = habSum
                    });
                }
            }

            return list.OrderByDescending(t => t.punto).ToList();
        }


        private static int v1 = 0;   // primer elemento
        private static int v2 = 1;   // segundo elemento

        public static void Fibonacci(int max)
        {
            for (int i = 0; i < max; i++)
            {
                var temp = v1;
                v1 = v2;
                v2 = v1 + temp;

                Console.WriteLine(v2);
            }
        }
    }

    public class OutPut
    {
        public string name { get; set; }
        public int punto { get; set; } = 0;


    }


    public class Candidato
    {
        public string name { get; set; }
        public int punto { get; set; } = 0;

        public List<string> habilidadList = new List<string>();
    }


    public class Habilidad
    {
        public string name { get; set; }
        public int punto { get; set; } = 0;
    }




}
