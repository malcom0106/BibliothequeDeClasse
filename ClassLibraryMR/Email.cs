using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace ClassLibraryMR
{
    public static class Email
    {
        private static SmtpClient SmtpClient(string serveur, int port, string identifiant, string password)
        {
            SmtpClient smtpClient = null;
            try
            {
                //Déclaration et instenciation des variables
                string Identifiant = identifiant;
                string Mdp = password;
                string serveurSmtp = serveur;
                int portSmtp = port;

                // instanciation du client 
                smtpClient = new SmtpClient(serveurSmtp,portSmtp);

                //Indique au client d'utiliser les information qu'on va lui transmettre
                smtpClient.UseDefaultCredentials = true;

                //Ajout des paramètres de connextion
                smtpClient.Credentials = new NetworkCredential(Identifiant, Mdp);

                //Indique au client que l'on passe par le reseau
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                //Activation du SSL
                smtpClient.EnableSsl = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return smtpClient;
        }

        public static bool SendEmail(string serveur, int port, string identifiant, string password, string sujet, string message, List<string> destinataires, List<string> copies = null)
        {
            bool isSend = false;
            try
            {
                //Instanciation et déclaration su client SMTP
                SmtpClient smtpClient = SmtpClient(serveur, port, identifiant, password);

                //Instanciation du Manager d'Email
                MailMessage mail = new MailMessage();

                //Expéditeur
                mail.From = new MailAddress(identifiant, identifiant);

                //Destinataires
                if (destinataires != null && destinataires.Count > 0)
                {
                    foreach (string destinataire in destinataires)
                    {
                        mail.To.Add(new MailAddress(destinataire));
                    }
                }                    

                //Copies
                if(copies != null && copies.Count > 0){
                    foreach (string destinataire in destinataires)
                    {
                        mail.To.Add(new MailAddress(destinataire));
                    }
                }                

                //Envoi 
                smtpClient.Send(mail);

                //Returne True si tout va bien 
                isSend = true;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return isSend;
        }
    }
}
