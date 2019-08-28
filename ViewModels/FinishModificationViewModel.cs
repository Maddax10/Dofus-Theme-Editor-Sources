using Dofus_Theme_Editor.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.MVVM.Commands;
using Toolbox.MVVM.ViewModels;
using Toolbox.Patterns.Mediator;
using GC = Toolbox.Controls.GestionControls;
using GW = Toolbox.GestionWindow.GestionWindow;

namespace Dofus_Theme_Editor.ViewModels
{
    class FinishModificationViewModel : ViewModelBase
    {
        private FinishModificationWindow fMW;

        public FinishModificationWindow FMW
        {
            get
            {
                return fMW;
            }
            set
            {
                if(value != fMW)
                {
                    fMW = value;
                    RaisePropertyChanged(nameof(FMW));
                }
            }
        }

        #region Commands
        //Close_Window_Command===============================================================================================================================//
        private RelayCommand _close_Window_Command;
        public RelayCommand Close_Window_Command
        {
            get
            {
                return _close_Window_Command ?? (_close_Window_Command = new RelayCommand(() => { GW.Close_Window(FMW); }, null));
            }
        } 
        #endregion
        public FinishModificationViewModel()
        {
            Messenger<FinishModificationWindow>.Instance.Register(Groups.ViewModels, Get_FMW_Instance);
        }

        private void Get_FMW_Instance(FinishModificationWindow FMW_Instance)
        {
            FMW = FMW_Instance;
            Move_Window();
        }

        private void Move_Window()
        {
            GC.Moving_Window(FMW);
        }
    }
}
