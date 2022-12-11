using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ООО__Телеком_Нева_Связь_.Models;

namespace ООО__Телеком_Нева_Связь_.Classes.Import
{
    public class JsonImport
    {
        public void Deserialize()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string path = openFileDialog.FileName;
            string json = File.ReadAllText(path);
            //data[] restoredPerson = JsonSerializer.Deserialize<data[]>(json);
            //List<data> dataList = new List<data>(restoredPerson);

            List<Subscribers> subscribersList;

            List<SubscriberAdress> subscriberAdresses = new List<SubscriberAdress>();

            using (DemoDBEntities db = new DemoDBEntities())
            {
                subscribersList = db.Subscribers.ToList();
            }

            foreach (var subscriber in subscribersList)
            {
                //var temp = dataList.Where(p => p.number == subscriber.ResidentialAddress).FirstOrDefault();
                //if (temp != null)
                //{
                //    subscriberAdresses.Add(new SubscriberAdress { SubscriberId = subscriber.Id, House = temp.house, Raion = temp.raion, Prefix = temp.prefix, Prefix_code = temp.prefix_code });
                //}
            }

            using (DemoDBEntities db = new DemoDBEntities())
            {
                db.SubscriberAdress.AddRange(subscriberAdresses);
                db.SaveChanges();
            }
        }          
    }
}
