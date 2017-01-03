using AdmissionContestCS.Domain;
using AsmissionContestCS.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsmissionContestCS.UI
{
    class AdmissionContestUI
    {

        public void MainLoop(CandidatController cctr, SectiiController sctr)
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
            throw new NotImplementedException();
        }

        private void AfisareCandidati()
        {
            throw new NotImplementedException();
        }

        private void UpdateSectie()
        {
            throw new NotImplementedException();
        }

        private void RemoveSectie()
        {
            throw new NotImplementedException();
        }

        private void AddSectie()
        {
            throw new NotImplementedException();
        }

        private void UpdateCandidat()
        {
            throw new NotImplementedException();
        }

        private void RemoveCandidat()
        {
            throw new NotImplementedException();
        }

        private void AddCandidat()
        {
            throw new NotImplementedException();
        }

        public void AfisareMeniu()
        {
            Console.WriteLine("--->   MENU   <---");
            Console.WriteLine("1 - Add Candidat");
            Console.WriteLine("2 - Remove Candidat");
            Console.WriteLine("3 - Remove Candidat");
            Console.WriteLine("4 - Update Candidat");
            Console.WriteLine("5 - Add Sectie");
            Console.WriteLine("6 - Remove Sectie");
            Console.WriteLine("7 - Update Sectie");
            Console.WriteLine("8 - All Candidati");
            Console.WriteLine("9 - All Sectii");
            Console.WriteLine("0 - Exit");
            Console.WriteLine();
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
                }

            }
            else
            {
                InvalidCmd(line);
            }
            return cmd;       
        }

        private void InvalidCmd(string str)
        {
            Console.WriteLine();
            Console.WriteLine("Comanda invalida: " + str);
            Console.WriteLine();
        }

    }
}
