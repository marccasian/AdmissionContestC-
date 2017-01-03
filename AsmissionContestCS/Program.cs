﻿using AdmissionContestCS.Repository;
using AsmissionContestCS.Controller;
using AsmissionContestCS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionContestCS
{
    class Program
    {
        static void Main(string[] args)
        {
            InMemoryRepository<Candidat, int> repoCand = new InMemoryRepository<Candidat, int>();
            InMemoryRepository<Sectie, int> repoSectii = new InMemoryRepository<Sectie, int>();
            CandidatController controllerCand = new CandidatController(repoCand);
            SectiiController controllerSectii = new SectiiController(repoSectii);
            Sectie s1 = new Sectie(1, "", -300);
            Sectie s2 = new Sectie(2, "UMF", 200);
            Candidat c1 = new Candidat(1, "Casian", "Theodor Mihali", 20, "0747127916");
            Candidat c2 = new Candidat(2, "Roxana", "Hasdeu", 21, "0751451605");
            ValidatorCandidat vc = new ValidatorCandidat();
            ValidatorSectie vs = new ValidatorSectie();
            try
            {
                vc.validate(c1);
                controllerCand.Save(c1);
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                vc.validate(c2);
                controllerCand.Save(c2);
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
            
            try
            {
                vs.validate(s1);
                controllerSectii.Save(s1);
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                vs.validate(s2);
                controllerSectii.Save(s2);
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("SECTII");
            foreach (Sectie e in controllerSectii.GetAll())
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("CANDIDATI");
            foreach (Candidat e1 in controllerCand.GetAll())
            {
                Console.WriteLine(e1);
            }
            Console.ReadLine(); 
        }
    }
}

