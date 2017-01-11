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
        public InscrieriController IController { get; set; }

        public AdmissionContestUI(CandidatController cctr, SectiiController sctr, InscrieriController ictr)
        {
            CController = cctr;
            SController = sctr;
            IController = ictr;
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
                    AddInscriere();
                }
                else if (8 == cmd)
                {
                    RemoveInscriere();
                }
                else if (9 == cmd)
                {
                    AfisareCandidati();
                }
                else if (10 == cmd)
                {
                    AfisareSectii();
                }
                else if (11 == cmd)
                {
                    AfisareInscrieri();
                }
            }
        }

        private void RemoveInscriere()
        {
            AfisareInscrieri();
            Enter();
            Console.WriteLine("     Dati id-ul inscrierii pe care doriti sa o stergeti:");
            string id_del = ReadInput();
            try
            {
                Inscriere i = IController.Remove(id_del);
                Console.WriteLine("Inscrierea: " + i.Id + " a fost stearsa!");
                Enter();
            }
            catch (CustomException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void AddInscriere()
        {
            Enter();
            int nr1, nr;
            Console.WriteLine("Adaugare inscriere:");
            AfisareSectii();
            Console.WriteLine("     Dati id-ul sectiei:");
            string IdS = ReadInput();
            AfisareCandidati();
            Console.WriteLine("     Dati id-ul candidatului:");
            string IdC = ReadInput();
            if (int.TryParse(IdS, out nr))
            {
                if (int.TryParse(IdC, out nr1))
                {
                    try
                    {
                        if (ExistIdSectie(nr))
                        {
                            if (ExistIdCandidat(nr1))
                            {
                                Inscriere i = IController.Save(nr, nr1);
                                Console.WriteLine("Inscrierea a fost adaugata!");
                                Enter();
                            }
                            else
                            {
                                Console.WriteLine("Nu exista nici o sectie cu id-ul introdus!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nu exista nici o sectie cu id-ul introdus!");
                        }
                    }
                    catch (CustomException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Id-ul candidatului trebuie sa fie un numar natural!");
                }
            }
            else
            {
                Console.WriteLine("Id-ul sectiei trebuie sa fie un numar natural!");
            }
        }

        private bool ExistIdSectie(int idS)
        {
            foreach(Sectie s in SController.GetAll())
            {
                if (s.Id == idS) return true;
            }
            return false;
        }

        private bool ExistIdCandidat(int idC)
        {
            foreach (Candidat c in CController.GetAll())
            {
                if (c.Id == idC) return true;
            }
            return false;
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

        private void AfisareInscrieri()
        {
            Enter();
            Console.WriteLine("---> Inscrieri <---");
            foreach (Inscriere i in IController.GetAll())
            {
                Console.WriteLine(i);
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
            Console.WriteLine("7 - Add Inscriere");
            Console.WriteLine("8 - Remove Inscriere");
            Console.WriteLine("9 - All Candidati");
            Console.WriteLine("10 - All Sectii");
            Console.WriteLine("11 - All Inscrieri");
            Console.WriteLine("0 - Exit");
            Enter();
            Console.WriteLine("Optiune: ");
        }


        private int ReadCmd()
        {
            int cmd = -1;
            string line = Console.ReadLine();

            if (int.TryParse(line,out cmd)) {
                if (cmd >= 0 && cmd <= 11)
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
