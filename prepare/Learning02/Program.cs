using System;

class Program
{
    static void Main(string[] args)
    {
        //setting current job
        Job job1 = new Job();
        job1._company = "AdvancedMD";
        job1._jobTitle = "Interface Delivery Analyst Sr";
        job1._startYear = 2022;
        job1._endYear = 2023;

        //setting previous job
        Job job2 = new Job();
        job2._company = "Sygnus Consulting";
        job2._jobTitle = "Application Manager";
        job2._startYear = 2017;
        job2._endYear = 2021;

        //setting resumen
        Resume resume = new Resume();
        resume._name = "Eduardo Fernandez";
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        // display values
        resume.Display();


    }
}