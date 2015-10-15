using AutoMapper;
using Caliburn.Micro;
using Newtonsoft.Json;
using StackQuestionsClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace StackQuestionsClient.ViewModels
{
    public class MainWindowViewModel : Screen
    {
        public BindableCollection<Stack_Question> QuestionList
        {
            get;
            private set;
        }

        public MainWindowViewModel()
        {
            this.QuestionList = new BindableCollection<Stack_Question>();
            
            Mapper.CreateMap<Item, Stack_Question>().ReverseMap();
            Mapper.CreateMap<Owner, Owner>();

            this.LaunchLoader();
        }

        public void Hyperlink_RequestNavigate(string argument)
        {
            Process.Start(new ProcessStartInfo(argument));
        }

        public bool CanRefresh()
        {
            return true;
        }

        public void Refresh()
        {
            this.QuestionList = new BindableCollection<Stack_Question>();

            this.LaunchLoader();
        }

        private async Task LaunchLoader()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    System.Threading.Thread.Sleep(5000);

                    this.Fill();
                }

            }, new System.Threading.CancellationToken());
        }

        private void Fill()
        {
            ServiceAPI api = new ServiceAPI();
            var result = api.GetLatestQuestion().Result;

            if (!string.IsNullOrEmpty(result.Content))
            {
                var list = JsonConvert.DeserializeObject<Rootobject>(result.Content).items;

                Stack_Question question;

                foreach (var item in list)
                {
                    question = Mapper.Map<Item, Stack_Question>(item);

                    if (!this.QuestionList.Any(x => x.Question_id == question.Question_id))
                    {
                        this.QuestionList.Insert(0, question);
                    }
                }

                //this.QuestionList.OrderBy(x => x.Creation_date);
            }
        }
    }
}
