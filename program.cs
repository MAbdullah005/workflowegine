using System;
using System.Collections.Generic;
namespace inter
{
    public interface Activicity
    {
        public void Execute();
      
       

    }
    public class CloudActivicity:Activicity
    {
       public void Execute()
        {
            Console.WriteLine("Uploading a Video to cloud storage");

        }
    }
    public class WebServer:Activicity
    {
       public void Execute()
        {
            Console.WriteLine("Call a web service provided by a third-party video encoding service to tell them you have a \r\nvideo ready for encoding");
        }
    }
    public class Email:Activicity
    {
        public void Execute()
        {
            Console.WriteLine("Sending an email to the owner of the video..");
        }
    }
    public class VideoRecord:Activicity
    {
        public void Execute()
        {
            Console.WriteLine("Change Status of the video record in Database to Processing...");
        }
    }
    public class Workflow
    {
        private readonly IList<Activicity> _activicity;
        public Workflow()
        {
            _activicity= new List<Activicity>();
        }
        public void Run(Workflow workflow)
        {
            foreach(var activ in _activicity)
            {
                activ.Execute();
            }

        }
        public void Activi(Activicity activ)
        {
            _activicity.Add(activ);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var workflow=new Workflow();
            workflow.Activi(new Email());
            workflow.Activi(new VideoRecord());
            workflow.Activi(new WebServer());
            workflow.Activi(new CloudActivicity());
            workflow.Run(new Workflow());
            
        }
    }
}
