using FTS.Service.Services;
using FTS.View.ServiceViews;
using FTS.View.ViewServices;

namespace FTS.View.Commons;

public class MainView
{
    //GENERIC VIEW UCHUN
    //private read-only WorkOutServiceView workOutServiceView = new WorkOutServiceView(new WorkOutService());
    //private read-only UserServiceView userServiceView = new UserServiceView();
    //private readonly ProgressRecordServiceView progressRecordServiceView = new ProgressRecordServiceView(new ProgressRecordService());
    //private readonly NuritionPlanServiceView nuritionPlanServiceView = new NuritionPlanServiceView(new NuritionPlanService());

    // INDIVIDUAL VIEW UCHUN
    private readonly NuritionPlanView nuritionPlanServiceView = new NuritionPlanView();
    private readonly UserView userServiceView = new UserView();
    private readonly ProgressRecordView progressRecordServiceView = new ProgressRecordView();
    private readonly WorkOutView workOutServiceView = new WorkOutView();

    public void MainMenu()
    {
        Console.Write("---------- Main menu ----------\n" +
                      "1. User\n" +
                      "2. ProgressRecord\n" +
                      "3. NuritionPlan\n" +
                      "4. WorkOut\n" +
                      "0. Exit\n" +
                      ">>> ");
        int n = int.Parse(Console.ReadLine()!);
        switch(n)
        {
            case 1: UserPage(); break;
            case 2: ProgressRecordPage(); break;
            case 3: NuritionPlanPage(); break;
            case 4: WorkOutPage(); break;
            case 5: return;
        }
            MainMenu();
    }

    public async void UserPage()
    {
        Console.Write("---------- UserPage ----------\n" +
                      "1. Create\n" +
                      "2. Update\n" +
                      "3. Delete\n" +
                      "4. GetById\n" +
                      "5. GetAll\n" +
                      "0. Back\n" +
                      ">>> ");
        int n = int.Parse(Console.ReadLine()!);
        switch (n)
        {
            case 1: await userServiceView.CreateAsync(); break;
            case 2: await userServiceView.UpdateAsync(); break;
            case 3: await userServiceView.DeleteAsync(); break;
            case 4: await userServiceView.GetByIdAsync(); break;
            case 5: userServiceView.GetAll(); break;
            case 0: MainMenu(); return;
        }
        UserPage();
    }

    public async void ProgressRecordPage()
    {
        Console.Write("---------- ProgressRecordPage ----------\n" +
                      "1. Create\n" +
                      "2. Update\n" +
                      "3. Delete\n" +
                      "4. GetById\n" +
                      "5. GetAll\n" +
                      "0. Back\n" +
                      ">>> ");
        int n = int.Parse(Console.ReadLine()!);
        switch (n)
        {
            case 1: await progressRecordServiceView.CreateAsync(); break;
            case 2: await progressRecordServiceView.UpdateAsync(); break;
            case 3: await progressRecordServiceView.DeleteAsync(); break;
            case 4: await progressRecordServiceView.GetByIdAsync(); break;
            case 5: progressRecordServiceView.GetAll(); break;
            case 0: MainMenu(); return;
        }
        ProgressRecordPage();
    }

    public async void NuritionPlanPage()
    {
        Console.Write("---------- NuritionPlanPage ----------\n" +
                      "1. Create\n" +
                      "2. Update\n" +
                      "3. Delete\n" +
                      "4. GetById\n" +
                      "5. GetAll\n" +
                      "0. Back\n" +
                      ">>> ");
        int n = int.Parse(Console.ReadLine()!);
        switch (n)
        {
            case 1: await nuritionPlanServiceView.CreateAsync(); break;
            case 2: await nuritionPlanServiceView.UpdateAsync(); break;
            case 3: await nuritionPlanServiceView.DeleteAsync(); break;
            case 4: await nuritionPlanServiceView.GetByIdAsync(); break;
            case 5: nuritionPlanServiceView.GetAll(); break;
            case 0: MainMenu(); return;
        }
        NuritionPlanPage();
    }

    public async void WorkOutPage()
    {
        Console.Write("---------- WorkOutPage ----------\n" +
                      "1. Create\n" +
                      "2. Update\n" +
                      "3. Delete\n" +
                      "4. GetById\n" +
                      "5. GetAll\n" +
                      "0. Back\n" +
                      ">>> ");
        int n = int.Parse(Console.ReadLine()!);
        switch (n)
        {
            case 1: await workOutServiceView.CreateAsync(); break;
            case 2: await workOutServiceView.UpdateAsync(); break;
            case 3: await workOutServiceView.DeleteAsync(); break;
            case 4: await workOutServiceView.GetByIdAsync(); break;
            case 5: workOutServiceView.GetAll(); break;
            case 0: MainMenu(); return;
        }
        WorkOutPage();
    }


    



    /*    public void MainMenu()
        {
            Console.WriteLine("---------- Main menu ----------");
            Console.Write("1. User\n" +
                          "2. ProgressRecord\n" +
                          "3. NuritionPlan\n" +
                          "4. WorkOut\n" +
                          "0. Exit\n" +
                          ">>> ");
            int n = int.Parse(Console.ReadLine()!);

            if (n is 0)
                return;
            else if (n < 5 && n > 0)
                WorkCommonFuntion(n);
            else
                MainMenu();
        }

        public async void WorkCommonFuntion(int choice)
        {
            dynamic temp = progressRecordServiceView;
            switch (choice)
            {
                case 1: temp = userServiceView; break;
                case 2: temp = progressRecordServiceView; break;
                case 3: temp = nuritionPlanServiceView; break;
                case 4: temp = workOutServiceView; break;
            }
            Console.WriteLine("---------- " + " ----------");
            Console.WriteLine("1. Create\n" +
                                "2. Update\n" +
                                "3. Delete\n" +
                                "4. GetById\n" +
                                "5. GetAll\n" +
                                "0. Back\n" +
                                ">>> ");
            int n = int.Parse(Console.ReadLine()!);
            switch (n)
            {
                case 1: await temp.CreateAsync(); break;
                case 2: await temp.UpdateAsync(); break;
                case 3: await temp.DeleteAsync(); break;
                case 4: await temp.GetByIdAsync(); break;
                case 5: temp.GetAll(); break;
                case 0: MainMenu(); return;
            }
            WorkCommonFuntion(choice);
        }*/
}