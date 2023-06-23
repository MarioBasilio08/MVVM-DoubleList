using List.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace List.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Traceability> listRigth; 
        private ObservableCollection<Traceability> listLeft;
        private Traceability selectedTraceability;

        private ICommand clickCommandRigth;
        private ICommand clickCommandLeft;
        private ICommand clickCommandRigthAll;
        private ICommand clickCommandLeftAll;

        public ObservableCollection<Traceability> ListRigth
        {
            get { return listRigth; }
            set
            {
                listRigth = value;
                OnPropertyChanged(nameof(listRigth));
            }
        }

        public ObservableCollection<Traceability> ListLeft
        {
            get { return listLeft; }
            set
            {
                listLeft = value;
                OnPropertyChanged(nameof(listLeft));
            }
        }

        public Traceability SelectedTraceability
        {
            get { return selectedTraceability; }
            set
            {
                selectedTraceability = value;
                OnPropertyChanged();
            }
        }

        public ICommand ClickCommandRigth
        {
            get
            {
                if (clickCommandRigth == null)
                {
                    clickCommandRigth = new RelayCommand(p => this.Move(ListLeft,ListRigth));
                }
                return clickCommandRigth;
            }
        }

        public ICommand ClickCommandLeft
        {
            get
            {
                if (clickCommandLeft == null)
                {
                    clickCommandLeft = new RelayCommand(p => this.Move(ListRigth, ListLeft));
                }
                return clickCommandLeft;
            }
        }

        public ICommand ClickCommandRigthAll
        {
            get
            {
                if (clickCommandRigthAll == null)
                {
                    clickCommandRigthAll = new RelayCommand(p => this.MoveAll(ListLeft,ListRigth,"izquierdo"));
                }
                return clickCommandRigthAll;
            }
        }

        public ICommand ClickCommandLeftAll
        {
            get
            {
                if (clickCommandLeftAll == null)
                {
                    clickCommandLeftAll = new RelayCommand(p => this.MoveAll(ListRigth,ListLeft,"derecho"));
                }
                return clickCommandLeftAll;
            }
        }
        public MainViewModel() { 
            ListRigth = new ObservableCollection<Traceability>();
            ListLeft = new ObservableCollection<Traceability>();

            Traceability t1 = new Traceability(1, "M12345");
            Traceability t2 = new Traceability(2, "N12345");
            Traceability t3 = new Traceability(3, "O12345");
            Traceability t4 = new Traceability(4, "P12345");
            Traceability t5 = new Traceability(5, "Q12345");

            ListRigth.Add(t1);
            ListRigth.Add(t2);
            ListRigth.Add(t3);
            ListRigth.Add(t4);
            ListRigth.Add(t5);

            Traceability t6 = new Traceability(6, "R12345");
            Traceability t7 = new Traceability(7, "NS12345");
            Traceability t8 = new Traceability(8, "T12345");
            Traceability t9 = new Traceability(9, "U12345");
            Traceability t10 = new Traceability(10, "V12345");

            ListLeft.Add(t6);
            ListLeft.Add(t7);
            ListLeft.Add(t8);
            ListLeft.Add(t9);
            ListLeft.Add(t10);
        }

        public void Move(ObservableCollection<Traceability> Source, ObservableCollection<Traceability> Destination)
        {
            if (SelectedTraceability != null)
            {
                Destination.Add(SelectedTraceability);
                Source.Remove(SelectedTraceability);
                SelectedTraceability = null;
            }
            else
            {
                MessageBox.Show("Selecciona un registro", "Información");
            }
        }

        public void MoveAll(ObservableCollection<Traceability> Source, ObservableCollection<Traceability> Destination, string lado)
        {
            if (Source.Count > 0)
            {
                while (Source.Count > 0)
                {
                    var tra = Source[0];
                    Source.RemoveAt(0);
                    Destination.Add(tra);
                }
            }
            else
            {
                MessageBox.Show($"No existen registros del lado {lado}", "Información");
            }
        }
    }

}
