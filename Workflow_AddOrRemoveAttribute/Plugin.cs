using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMTANGEE.SDK.Messages;

namespace Workflow_Newsletter
{
    public class Plugin : AMTANGEE.Workflow.IMessages
    {
        public void EmailReceived(Email email, DateTime dateTime)
        {
            if (!email.HasContact)
                return;

            if (email.Subject.ToUpper().Trim().StartsWith("SUBSCRIBE:"))
            {
                string attribute = AMTANGEE.SDK.Global.CopyToPattern(email.Subject.Trim().ToUpper(), ":");
                if (attribute.Trim().Length == 0)
                    return;

                AMTANGEE.SDK.Contacts.Attribute attributeObject = null;
                if(attribute.Trim().Length  == 36 || attribute.Trim().Length == 38)
                {
                    try
                    {
                        attributeObject = new AMTANGEE.SDK.Contacts.Attribute(new Guid(attribute));
                        if (attributeObject == null || !attributeObject.ExistsAndLoadedAndRights)
                            attributeObject = null;
                    }
                    catch { }
                }

                if(attributeObject == null)
                {
                    attributeObject = new AMTANGEE.SDK.Contacts.Attribute(AMTANGEE.SDK.Global.OwnLocation, attribute, false);
                    if (attributeObject == null || !attributeObject.ExistsAndLoadedAndRights)
                        attributeObject = null;
                }

                if (attributeObject != null)
                {
                    if (!email.Contact.Attributes.Contains(attributeObject))
                    {
                        email.Contact.Attributes.Add(attributeObject);
                        email.Contact.Save();
                        email.Subject = "Attribute added - " + email.Subject;
                        email.Save();
                    }
                    else
                    {
                        email.Subject = "Attribute not added (already added) - " + email.Subject;
                        email.Save();
                    }
                }
            }

            if (email.Subject.ToUpper().Trim().StartsWith("UNSUBSCRIBE:"))
            {
                string attribute = AMTANGEE.SDK.Global.CopyToPattern(email.Subject.Trim().ToUpper(), ":");
                if (attribute.Trim().Length == 0)
                    return;

                AMTANGEE.SDK.Contacts.Attribute attributeObject = null;
                if (attribute.Trim().Length == 36 || attribute.Trim().Length == 38)
                {
                    try
                    {
                        attributeObject = new AMTANGEE.SDK.Contacts.Attribute(new Guid(attribute));
                        if (attributeObject == null || !attributeObject.ExistsAndLoadedAndRights)
                            attributeObject = null;
                    }
                    catch { }
                }

                if (attributeObject == null)
                {
                    attributeObject = new AMTANGEE.SDK.Contacts.Attribute(AMTANGEE.SDK.Global.OwnLocation, attribute, false);
                    if (attributeObject == null || !attributeObject.ExistsAndLoadedAndRights)
                        attributeObject = null;
                }

                if (attributeObject != null)
                {
                    if (email.Contact.Attributes.Contains(attributeObject))
                    {
                        email.Contact.Attributes.Remove(attributeObject);
                        email.Contact.Save();
                        email.Subject = "Attribute removed - " + email.Subject;
                        email.Save();
                    }
                    else
                    {
                        email.Subject = "Attribute not removed (already removed) - " + email.Subject;
                        email.Save();
                    }
                }
            }
        }


        #region not needed
        public void AppointmentNotificationReceived(AppointmentNotification notification, DateTime dateTime)
        {
            
        }

        public void CallNotificationReceived(Call call, DateTime dateTime)
        {
            
        }

        public void EmailSent(Email email, DateTime dateTime)
        {
            
        }

        public void FaxReceived(Fax fax, DateTime dateTime)
        {
            
        }

        public void FaxSent(Fax fax, DateTime dateTime)
        {
            
        }

        public void MessageChanged(MessageBase message, DateTime dateTime)
        {
            
        }

        public void MessageDeleted(Guid guid, DateTime dateTime)
        {
            
        }

        public void NotificationReceived(Notification notification, DateTime dateTime)
        {
            
        }

        public void ShortMessageReceived(ShortMessage shortMessage, DateTime dateTime)
        {
            
        }

        #endregion
    }
}
