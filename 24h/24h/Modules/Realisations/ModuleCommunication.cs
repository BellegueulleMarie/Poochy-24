using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IACryptOfTheNecroDancer.Modules.Realisations
{
    /// <summary>
    ///Module en charge de la communication avec le sereur
    ///</summary>
    public class ModuleCommunication : Module
    {
        #region --- Attributs ---
        private TcpClient client;           //Le client TCP
        private StreamReader fluxEntrant;   //Le flux entrant depuis le serveur
        private StreamWriter fluxSortant;   //Le flux sortant vers le serveur
        #endregion

        #region --- Constructeurs ---
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <param name="ia">L'IA dont dépend le module</param>
        public ModuleCommunication(IA ia) : base(ia) { }
        #endregion

        #region --- Méthodes ---
        /// <summary>
        /// Création du client TCP
        /// </summary>
        private void Connexion()
        {
            this.client = new TcpClient("127.0.0.1", 1234);
        }

        /// <summary>
        /// Création du flux entrant et du flux sortant
        /// </summary>
        private void CreationFlux()
        {
            this.fluxEntrant = new StreamReader(this.client.GetStream());
            this.fluxSortant = new StreamWriter(this.client.GetStream())
            {
                AutoFlush = true
            };
        }

        /// <summary>
        /// Etablir la connexion avec le serveur
        /// </summary>
        public void EtablirConnexion()
        {
            this.Connexion();
            this.CreationFlux();
            Console.WriteLine("--- Début de la communication avec le serveur ---");
            Console.WriteLine();
        }

        /// <summary>
        /// Envoyer un message au serveur
        /// </summary>
        /// <param name="message">Le message à envoyer</param>
        public void EnvoyerMessage(string message)
        {
            Console.WriteLine(">> " + message);
            this.fluxSortant.WriteLine(message);
        }

        /// <summary>
        /// Recevoir un message depuis le serveur (bloque jusqu'à réception d'un message)
        /// </summary>
        public String RecevoirMessage()
        {
            String message = this.fluxEntrant.ReadLine();
            Console.WriteLine("<< " + message);
            return message;
        }

        /// <summary>
        /// Termine la connexion au serveur
        /// </summary>
        public void FermerConnexion()
        {
            Console.WriteLine();
            Console.WriteLine("--- Fin de la communication avec le serveur ---");
            this.client.Close();
        }
        #endregion
    }
}
