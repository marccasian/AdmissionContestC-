using AdmissionContestCS;
using AdmissionContestCS.Domain;
using AsmissionContestCS.Controller;
using AsmissionContestCS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsmissionContestCS.UI
{
    class AdmissionContestUI
    {

        public CandidatController CController { get; set; }
        public SectiiController SController { get; set; }

        public AdmissionContestUI(CandidatController cctr, SectiiController sctr)
        {
            CController = cctr;
            SController = sctr;
            MainLoop();
        }


        public void MainLoop()
        {
            while (true)
            {
                AfisareMeniu();
                int cmd = ReadCmd();
                if (0 == cmd)
                {
                    Console.WriteLine("Ati ales sa iesiti din aplicatie!");
                    Console.WriteLine("Press enter to Exit!");
                    Console.ReadLine();
                    break;
                }
                else if (1 == cmd)
                {
                    AddCandidat();
                }
                else if (2 == cmd)
                {
                    RemoveCandidat();
                }
                else if (3 == cmd)
                {
                    UpdateCandidat();
                }
                else if (4 == cmd)
                {
                    AddSectie();
                }
                else if (5 == cmd)
                {
                    RemoveSectie();
                }
                else if (6 == cmd)
                {
                    UpdateSectie();
                }
                else if (7 == cmd)
                {
                    AfisareCandidati();
                }
                else if (8 == cmd)
                {
                    AfisareSectii();
                }
            }
        }

        private void AfisareSectii()
        {
            Enter();
            Console.WriteLine("---> Sectii <---");
            foreach (Sectie s in SController.GetAll())
            {
                Console.WriteLine(s);
            }
        }

        private void AfisareCandidati()
        {
            Enter();
            Console.WriteLine("---> Candidati <---");
            foreach (Candidat c in CController.GetAll())
            {
                Console.WriteLine(c);
            }
        }

        private void AddSectie()
        {
            Enter();
            Console.WriteLine("Adaugare sectie:");
            Console.WriteLine("     Dati numele:");
            string nume = ReadInput();
            Console.WriteLine("     Dati numarul de locuri:");
            string nrLoc = ReadInput();
            try
            {
                Sectie s = SController.Save(nume, nrLoc);
                Console.WriteLine("Sectia a fost adaugata!");
                Enter();
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private string ReadInput()
        {
            string line = Console.ReadLine();
            return line;
        }

        private void UpdateSectie()
        {
            AfisareSectii();
            Enter();
            Console.WriteLine("     Dati id-ul sectiei pe care doriti sa o modificati:");
            string id_mod = ReadInput();
            Console.WriteLine("     Dati noul nume:");
            string nume = ReadInput();
            Console.WriteLine("     Dati noul numar de locuri:");
            string nrLoc = ReadInput();
            try
            {
                Sectie s = SController.Update(id_mod, nume, nrLoc);
                Console.WriteLine("Sectia: " + s.Nume + " a fost modificata!");
                Enter();
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Enter()
        {
            Console.WriteLine();
        }

        private void RemoveSectie()
        {
            AfisareSectii();
            Enter();
            Console.WriteLine("     Dati id-ul sectiei pe care doriti sa o stergeti:");
            string id_del = ReadInput();
            try
            {
                Sectie s = SController.Remove(id_del);
                Console.WriteLine("Sectia: "+s.Nume+" a fost stearsa!");
                Enter();
            }
            catch ( CustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void UpdateCandidat()
        {
            AfisareCandidati();
            Enter();
            Console.WriteLine("     Dati id-ul candidatului pe care doriti sa il modificati:");
            string id_mod = ReadInput();
            Console.WriteLine("     Dati noul nume:");
            string nume = ReadInput();
            Console.WriteLine("     Dati noua adresa:");
            string adresa = ReadInput();
            Console.WriteLine("     Dati noua varsta:");
            string varsta = ReadInput();
            Console.WriteLine("     Dati noul numar de telefon:");
            string nrTel = ReadInput();
            try
            {
                Candidat c = CController.Update(id_mod, nume, adresa, varsta, nrTel);
                Console.WriteLine("Candidatul: " + c.Nume + " a fost modificat!");
                Enter();
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void RemoveCandidat()
        {
            AfisareCandidati();
            Enter();
            Console.WriteLine("     Dati id-ul candidatului pe care doriti sa il stergeti:");
            string id_del = ReadInput();
            try
            {
                Candidat c = CController.Remove(id_del);
                Console.WriteLine("Candidatul: " + c.Nume + " a fost sters!");
                Enter();
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AddCandidat()
        {
            Enter();
            Console.WriteLine("Adaugare candidat:");
            Console.WriteLine("     Dati numele:");
            string nume = ReadInput();
            Console.WriteLine("     Dati adresa:");
            string adresa = ReadInput();
            Console.WriteLine("     Dati varsta:");
            string varsta = ReadInput();
            Console.WriteLine("     Dati numarul de telefon:");
            string nrTel = ReadInput();
            try
            {
                Candidat c = CController.Save(nume, adresa, varsta, nrTel);
                Console.WriteLine("Candidatul a fost adaugat!");
                Enter();
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AfisareMeniu()
        {
            Console.WriteLine("--->   MENU   <---");
            Console.WriteLine("1 - Add Candidat");
            Console.WriteLine("2 - Remove Candidat");
            Console.WriteLine("3 - Update Candidat");
            Console.WriteLine("4 - Add Sectie");
            Console.WriteLine("5 - Remove Sectie");
            Console.WriteLine("6 - Update Sectie");
            Console.WriteLine("7 - All Candidati");
            Console.WriteLine("8 - All Sectii");
            Console.WriteLine("0 - Exit");
            Enter();
            Console.WriteLine("Optiune: ");
        }


        private int ReadCmd()
        {
            int cmd = -1;
            string line = Console.ReadLine();

            if (int.TryParse(line,out cmd)) {
                if (cmd >= 0 && cmd <= 9)
                {
                    return cmd;
                }
                else
                {
                    InvalidCmd(line);
                    return -1;
                }

            }
            else
            {
                InvalidCmd(line);
                return -1;
            }     
        }

        private void InvalidCmd(string str)
        {
            Console.WriteLine("Comanda invalida: " + str);
            Enter();
        }

    }
}
