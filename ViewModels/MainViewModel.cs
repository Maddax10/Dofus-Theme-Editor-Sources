using Dofus_Theme_Editor.View;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Toolbox.Manipulation_Images.HSL;
using Toolbox.MVVM.ViewModels;
using Toolbox.Patterns.Mediator;
using GF = Toolbox.Fichiers.GestionFichiers;
using GC = Toolbox.Controls.GestionControls;
using GW = Toolbox.GestionWindow.GestionWindow;
using Toolbox.MVVM.Commands;
using System.Windows;

namespace Dofus_Theme_Editor.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        #region Variables

        // ........................................TSL USER........................................ //

        //..........................//
        //        Teinte            //
        //..........................//

        // ......................MaxT...................... //
        private int _maxT;
        public int MaxT
        {
            get
            {
                return _maxT;
            }
            set
            {
                if(value != _maxT)
                {
                    _maxT = value;
                    RaisePropertyChanged(nameof(MaxT));
                }
            }
        }

        // ......................MinT...................... //
        private int _minT;
        public int MinT
        {
            get
            {
                return _minT;
            }
            set
            {
                if(value != _minT)
                {
                    _minT = value;
                    RaisePropertyChanged(nameof(MinT));
                }
            }
        }

        // ......................PasT...................... //
        private double _pasT;
        public double PasT
        {
            get
            {
                return _pasT;
            }
            set
            {
                if(value != _pasT)
                {
                    _pasT = value;
                    RaisePropertyChanged(nameof(PasT));

                }

            }
        }
        // ......................TeinteUser...................... //
        private double _teinteUser;
        public double TeinteUser
        {
            get
            {
                return _teinteUser;
            }
            set
            {
                if(value != _teinteUser)
                {
                    _teinteUser = value;
                    RaisePropertyChanged(nameof(TeinteUser));
                    //Comme ça, ça change les valeurs de Rouge, Vert, Bleu
                    Hls_To_Rgb_Tchat();
                }
            }
        }
        //..........................//
        //        Saturation        //
        //..........................//

        // ......................MaxS...................... //
        private double _maxS;
        public double MaxS
        {
            get
            {
                return _maxS;
            }
            set
            {
                if(value != _maxS)
                {
                    _maxS = value;
                    RaisePropertyChanged(nameof(MaxS));
                }
            }
        }

        // ......................MinS...................... //
        private double _minS;
        public double MinS
        {
            get
            {
                return _minS;
            }
            set
            {
                if(value != _minS)
                {
                    _minS = value;
                    RaisePropertyChanged(nameof(MinS));
                }
            }
        }

        // ......................ModifyCommand...................... //
        private double _pasS;
        public double PasS
        {
            get
            {
                return _pasS;
            }
            set
            {
                if(value != _pasS)
                {
                    _pasS = value;
                    RaisePropertyChanged(nameof(PasS));
                }
            }
        }
        
        // ......................ModifyCommand...................... //
        private double _valS;
        public double SaturationUser
        {
            get
            {
                return _valS;
            }
            set
            {
                if(value != _valS)
                {
                    _valS = value;
                    RaisePropertyChanged(nameof(SaturationUser));
                    //Comme ça, ça change les valeurs de Rouge, Vert, Bleu
                    Hls_To_Rgb_Tchat();
                }
            }
        }
        
        //..........................//
        //        Luminosite        //
        //..........................//

        // ......................ModifyCommand...................... //
        private double _maxL;
        public double MaxL
        {
            get
            {
                return _maxL;
            }
            set
            {
                if(value != _maxL)
                {
                    _maxL = value;
                    RaisePropertyChanged(nameof(MaxL));
                }
            }
        }

        // ......................ModifyCommand...................... //
        private double _minL;
        public double MinL
        {
            get
            {
                return _minL;
            }
            set
            {
                if(value != _minL)
                {
                    _minL = value;
                    RaisePropertyChanged(nameof(MinL));
                }
            }
        }

        // ......................ModifyCommand...................... //
        private double _pasL;
        public double PasL
        {
            get
            {
                return _pasL;
            }
            set
            {
                if(value != _pasL)
                {
                    _pasL = value;
                    RaisePropertyChanged(nameof(PasL));
                }
            }
        }

        // ......................ModifyCommand...................... //
        private double _valL;
        public double LuminositeUser
        {
            get
            {
                return _valL;
            }
            set
            {
                if(value != _valL)
                {
                    _valL = value;
                    RaisePropertyChanged(nameof(LuminositeUser));
                    //Comme ça, ça change leL valeurL de Rouge, Vert, Bleu

                    Hls_To_Rgb_Tchat();

                }
            }
        }

        //..........................//
        //        RGB User          //
        //..........................//

        // ......................ModifyCommand...................... //
        private int _rougeUser;
        public int RougeUser
        {
            get
            {
                return _rougeUser;
            }
            set
            {
                if(value != _rougeUser)
                {
                    _rougeUser = value;
                    RaisePropertyChanged(nameof(RougeUser));

                }
            }
        }

        // ......................ModifyCommand...................... //
        private int _vertUser;
        public int VertUser
        {
            get
            {
                return _vertUser;
            }
            set
            {
                if(value != _vertUser)
                {
                    _vertUser = value;
                    RaisePropertyChanged(nameof(VertUser));
                }
            }
        }

        // ......................ModifyCommand...................... //
        private int _bleuUser;
        public int BleuUser
        {
            get
            {
                return _bleuUser;
            }
            set
            {
                if(value != _bleuUser)
                {
                    _bleuUser = value;
                    RaisePropertyChanged(nameof(BleuUser));
                }
            }

        }

        //..........................//
        //        TSL/HSL IMAGE     //
        //..........................//
        public double TeinteImage
        {
            get; set;
        }
        public double SaturationImage
        {
            get; set;
        }
        public double LuminositeImage
        {
            get; set;
        }
        //..........................//
        //        RGB IMAGE         //
        //..........................//
        public int RougeImage
        {
            get; set;
        }
        public int VertImage
        {
            get; set;
        }
        public int BleuImage
        {
            get; set;
        }
        public int AlphaImage
        {
            get; set;
        }
        //..........................//
        //        Autres            //
        //..........................//
        private string _bgColor;
        public string BgColor
        {
            get
            {
                return _bgColor;
            }
            set
            {
                if(value != _bgColor)
                {
                    _bgColor = value;
                    RaisePropertyChanged(nameof(BgColor));
                }
            }
        }
        // ......................List_Files_Names...................... //
        ObservableCollection<string> List_Files_Names;
        // ......................Path...................... //
        private string _path;

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                if(value != _path)
                {
                    _path = value;
                    RaisePropertyChanged(nameof(Path));
                }
            }
        }

        // ......................Img_Previ_Source1...................... //
        private string _imgPreviSource1;
        public string Img_Previ_Source1
        {
            get
            {
                return _imgPreviSource1;
            }
            set
            {
                if(value != _imgPreviSource1)
                {
                    _imgPreviSource1 = value;
                    RaisePropertyChanged(nameof(Img_Previ_Source1));
                }
            }
        }

        // ......................Img_Previ_Source2...................... //
        private string _imgPreviSource2;
        public string Img_Previ_Source2
        {
            get
            {
                return _imgPreviSource2;
            }
            set
            {
                if(value != _imgPreviSource2)
                {
                    _imgPreviSource2 = value;
                    RaisePropertyChanged(nameof(Img_Previ_Source2));
                }
            }
        }

        // ......................Image_Previsu_Name...................... //
        private string _image_Previsu_Name;

        public string Image_Previsu_Name
        {
            get
            {
                return _image_Previsu_Name;
            }
            set
            {
                if(value != _image_Previsu_Name)
                {
                    _image_Previsu_Name = value;
                    RaisePropertyChanged(nameof(Image_Previsu_Name)); 
                }
            }
        }

        // ......................File_config_Txt_Path...................... //
        private string _fileImagesNamesTxtPath;
        public string File_config_Txt_Path
        {
            get
            {
                return _fileImagesNamesTxtPath;
            }
            set
            {
                if(value != _fileImagesNamesTxtPath)
                {
                    _fileImagesNamesTxtPath = value;
                    RaisePropertyChanged(nameof(File_config_Txt_Path));
                }
            }
        }
        // ......................CountLoadedImage...................... //
        private string _countLoadedImage;
        public string CountLoadedImage
        {
            get
            {
                return _countLoadedImage;
            }
            set
            {
                value = value + " images chargées";
                if(value != _countLoadedImage)
                {
                    _countLoadedImage = value;
                    RaisePropertyChanged(nameof(CountLoadedImage));
                }
            }
        }
        // ......................Folder_Theme_Path...................... //
        private string _folderTheme_Path;
        public string Folder_Theme_Path
        {
            get
            {
                return _folderTheme_Path;
            }
            set
            {
                if(value != _folderTheme_Path)
                {
                    _folderTheme_Path = value;
                    RaisePropertyChanged(nameof(Folder_Theme_Path));
                }

            }
        }

        // ......................BackgroundSource...................... //
        private string _backgroundSource;
        public string BackgroundSource
        {
            get
            {
                return _backgroundSource;
            }
            set
            {
                if(value != _backgroundSource)
                {
                    _backgroundSource = value;
                    RaisePropertyChanged(nameof(BackgroundSource));
                }
            }
        }

        // ......................IconSource...................... //
        private string _iconSource;
        public string IconSource
        {
            get
            {
                return _iconSource;
            }
            set
            {
                if(value != _iconSource)
                {
                    _iconSource = value;
                    RaisePropertyChanged(nameof(IconSource));
                }
            }
        }

        // ......................CountImageModified...................... //
        private int _countImageModified;
        public int CountImageModified
        {
            get
            {
                return _countImageModified;
            }
            set
            {
                if(value != _countImageModified)
                {

                    _countImageModified = value;
                    RaisePropertyChanged(nameof(CountImageModified));

                }
            }
        }

        // ......................CountImageModified...................... //
        private FinishModificationWindow _fMW_Instance;

        public FinishModificationWindow FMW_Instance
        {
            get
            {
                return _fMW_Instance;
            }
            set
            {
                if(value != _fMW_Instance)
                {
                    _fMW_Instance = value;
                    RaisePropertyChanged(nameof(FMW_Instance));
                }
            }
        }

        #endregion

        #region Constantes
        private const int MaxTsl = 360;
        private const int MaxRvb = 255;
        private const int MaxRvbFois2 = MaxRvb * 2;
        private const double MaxTslSur2 = MaxTsl / 2.0;
        private const double MaxTslSur3 = MaxTsl / 3.0;
        private const double MaxTsl2Sur3 = MaxTsl * 2.0 / 3.0;
        private const string NomBackgroundImage = "background.png";
        private const string NomIcon = "Icon.ico";
        private const string ZeroImageCharged = "0 images chargées";
        #endregion

        #region Commandes

        // ......................ModifyCommand...................... //
        private RelayCommand _modifyCommand;
        public RelayCommand ModifyCommand
        {

            get
            {

                return _modifyCommand ?? (_modifyCommand = new RelayCommand(Modify_All_Images, CanModifyAllImages));
            }

        }
        
        // ......................ModifyCommand...................... //
        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {

            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(Load_Files, Can_Load_Files));
            }
        }
        
        // ......................ModifyCommand...................... //
        private RelayCommand _apercuCommand;
        public RelayCommand ApercuCommand
        {
            get
            {
                return _apercuCommand ?? (_apercuCommand = new RelayCommand(Apercu, CanApercu));
            }

        }
        
        // ......................ModifyCommand...................... //
        private RelayCommand _loadFilesCommand;
        public RelayCommand LoadFilesCommand
        {
            get
            {
                return _loadFilesCommand ?? (_loadFilesCommand = new RelayCommand(Load_Files, Can_Load_Files));
            }

        }
        
        // ......................ModifyCommand...................... //
        private RelayCommand _getFileImagesNamesCommand;
        public RelayCommand GetFileImagesNamesCommand
        {
            get
            {
                return _getFileImagesNamesCommand ?? (_getFileImagesNamesCommand = new RelayCommand(Browse_File_ImageName, null));
            }
        }
        
        // ......................ModifyCommand...................... //
        private RelayCommand _getFolderThemeCommand;
        public RelayCommand GetFolderThemeCommand
        {
            get
            {
                return _getFolderThemeCommand ?? (_getFolderThemeCommand = new RelayCommand(Browse_FolderSearch, null));
            }

        }
        
        // ......................ModifyCommand...................... //
        private RelayCommand _deleteCommand;

        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand(Delete_Image_Charged, Can_Delete_Image_Charged));
            }

        }

        // ......................AppdataCommand...................... //
        private RelayCommand _appdataCommand;
        public RelayCommand AppdataCommand
        {
            get
            {
                return _appdataCommand ?? (_appdataCommand = new RelayCommand(GoAppdataFolder, null));
            }

        }

        // ......................Close_Window_Command...................... //
        private RelayCommand _close_Window_Command;

        public RelayCommand Close_Window_Command
        {
            get
            {
                return _close_Window_Command ?? (_close_Window_Command = new RelayCommand(Close_Window, null));
            }

        }

        #endregion

        public MainViewModel()
        {
            //0 - 360
            TeinteUser = 0;
            MaxT = MaxTsl;
            MinT = 0;
            PasT = 0.5;

            SaturationUser = MaxTslSur2;
            //0 - 360
            MaxS = MaxTsl;
            MinS = 0;
            PasS = 0.1;

            LuminositeUser = MaxTslSur2;
            //0 à 360 
            MaxL = MaxTsl * 0.65;
            MinL = MaxTsl * 0.35;
            PasL = 0.1;

            Image_Previsu_Name = "Theme1sur2.png";
            Img_Previ_Source1 = GF.Get_Local_Path() + "newImages\\" + Image_Previsu_Name;
            Img_Previ_Source2 = GF.Get_Local_Path() + "images\\Theme2sur2.png";

            Path = GF.Get_Local_Path();

            List_Files_Names = new ObservableCollection<string>();

            File_config_Txt_Path = GF.Get_Local_Path() + "config.txt";
            //Pour que Folder_Theme_Path ne soit pas null, et que le comportement du bouton "modifier le theme" soit correct
            Folder_Theme_Path = "";

            //Création du dossier s'il n'existe pas, si le dossier existe déjà, la fonction ignore la création et passe au dossier suivant à créer
            GF.Create_Folder(Path + "Nouveau thème\\");

            BackgroundSource = Path + "images\\" + NomBackgroundImage;
            IconSource = Path + "images\\" + NomIcon;

            CountLoadedImage = "0";

            GC.Moving_Window(GW.Get_MainWindow_Instance());
        }

        #region Fonctions
        private void ModifyApercu()//nameImage avec l'extension de l'image (.png ou .jpg) ex : "img.png"
        {
            /*Si l'image à déjà été modifié 1 fois, un "e" à été ajouté, donc il va chercher dans "images/Theme1sur2e.png" au
			lieu de "images/Theme1sur2.png" donc il ne va rien trouver d'où l'assignation*/
            string nameImage = "Theme1sur2.png";

            using(Bitmap bmp = new Bitmap(Path + "images\\" + nameImage))
            {
                //get image dimension
                int width = bmp.Width;
                int height = bmp.Height;

                //red green blue image
                for(int y = 0; y < height; y++)
                {
                    for(int x = 0; x < width; x++)
                    {

                        //get pixel value
                        Modify_Hls_Values(bmp, x, y);

                        bmp.SetPixel(x, y, Color.FromArgb(AlphaImage, RougeImage, VertImage, BleuImage));

                    }
                }
                //Je ne peux pas écraser une image que mon programme utilise
                Image_Previsu_Name = GF.Get_New_Image_Previsu_Name(Image_Previsu_Name);
                bmp.Save(Path + "newImages\\" + Image_Previsu_Name);
                Img_Previ_Source1 = GF.Get_New_Image_Previsu_Name(Img_Previ_Source1);

            }

        }
        //================================================================================================//
        private void ModifyOneImage(string nameImage, string pathFile)//nameImage avec l'extension de l'image (.png ou .jpg) ex : "img.png"
        {
            //on écrase l'ancienne image par la suivante dans le fichier texte :
            bool IsValid = File.Exists(pathFile + "\\" + nameImage);

            if(IsValid)
            {
                using(Bitmap bmp = new Bitmap(pathFile + "\\" + nameImage))
                {
                    //get image dimension
                    int width = bmp.Width;
                    int height = bmp.Height;

                    //red green blue image
                    for(int y = 0; y < height; y++)
                    {
                        for(int x = 0; x < width; x++)
                        {
                            Modify_Hls_Values(bmp, x, y);

                            //On réécrit le pixel
                            bmp.SetPixel(x, y, Color.FromArgb(AlphaImage, RougeImage, VertImage, BleuImage));

                        }
                    }
                    //Je ne peux pas écraser une image que mon programme utilise, donc il faut trouver une solution
                    //Créer un nouveau dossier "DarkStone Modify"

                    bmp.Save(Path + "Nouveau thème\\" + nameImage);
                    CountImageModified++;
                }
            }

        }

        //================================================================================================//
        private void Modify_Hls_Values(Bitmap bmp, int x, int y)
        {
            //1) Créer le pixel à partir de la position (x,y)
            //2) Changer le RGB du pixel en HLS
            //3) Modifier les valeurs HLS de l'objet 
            //4) reconvertir le HLS en RGB
            //5) Affectation des nouvelles valeurs RGB

            //1)
            Color pixel = bmp.GetPixel(x, y);
            //2)
            HSLColor hslColor = new HSLColor(pixel.R, pixel.G, pixel.B);
            //3)
            hslColor = Modify_Hls_Image_Properties(hslColor);
            //4)
            Color rgbColor = (Color)hslColor;
            //5)
            RougeImage = rgbColor.R;
            VertImage = rgbColor.G;
            BleuImage = rgbColor.B;
            AlphaImage = pixel.A;

        }
        //================================================================================================//
        private HSLColor Modify_Hls_Image_Properties(HSLColor hslColor)
        {
            hslColor.Hue = TeinteUser;
            hslColor.Saturation = SaturationUser;
            //Si la luminositeUser < 0.5 ça veut dire qu'on doit retirer de la luminosité au LuminositeImage et inversément
            double diff;
            if(LuminositeUser < 180)
            {
                diff = -(MaxTslSur2 - LuminositeUser);
            }
            else
            {
                diff = (LuminositeUser - MaxTslSur2);
            }
            hslColor.Luminosity += diff;
            hslColor.Luminosity = hslColor.Luminosity < 0 ? 0 : hslColor.Luminosity;
            hslColor.Luminosity = hslColor.Luminosity > MaxTsl ? MaxTsl : hslColor.Luminosity;

            return hslColor;
        }
        //================================================================================================//
        private void Hls_To_Rgb_Tchat()
        {//Fonction pour les curseurs, ça change la couleur du rectangle en dessous de l'aperçu
            double tmp = LuminositeUser - (0.3 * 360);
            tmp = tmp > MaxTsl ? MaxTsl : tmp;
            tmp = tmp < 0 ? 0 : tmp;
            HSLColor hslColor = new HSLColor(TeinteUser, SaturationUser, tmp);

            Color rgbColor = (Color)hslColor;

            RougeUser = rgbColor.R;
            VertUser = rgbColor.G;
            BleuUser = rgbColor.B;

            Rgb_To_String();

        }
        //================================================================================================//
        private void Rgb_To_String()
        {
            BgColor = "#";
            BgColor += Convert.ToString(RougeUser, 16).Length < 2 ? "0" + Convert.ToString(RougeUser, 16) : Convert.ToString(RougeUser, 16);
            BgColor += Convert.ToString(VertUser, 16).Length < 2 ? "0" + Convert.ToString(VertUser, 16) : Convert.ToString(VertUser, 16);
            BgColor += Convert.ToString(BleuUser, 16).Length < 2 ? "0" + Convert.ToString(BleuUser, 16) : Convert.ToString(BleuUser, 16);
        }
        //================================================================================================//
        public bool ModifyColorXml(string FilePath)
        {
            //Accepte en argument, le chemin d'accès vers le fichier à modifier, la ligne à laquelle modifier la valeur, la phrase qui va remplacer la ligne
            ObservableCollection<string> ListFile = new ObservableCollection<string>();
            if(File.Exists(FilePath))
            {

                string LigneEnCoursDeLecture;

                string LigneAModifier = "<entry key=\"chat.bgColor\">0x1c331b</entry>";
                using(StreamReader sr = File.OpenText(FilePath))
                {
                    LigneEnCoursDeLecture = sr.ReadLine();
                    //S'il n'y a plus de ligne à lire, sr.Peek() renvoit -1
                    while(sr.Peek() != -1)
                    {
                        LigneEnCoursDeLecture = GF.Delete_Spaces_Before_First_Word(LigneEnCoursDeLecture);

                        //On vérifie que la taille de la ligne est > 25 car sinon il y a une erreur avec le substring
                        if(LigneEnCoursDeLecture.Length > 25)
                        {
                            string tmp1 = LigneEnCoursDeLecture.Substring(12, 12);
                            string tmp2 = LigneAModifier.Substring(12, 12);

                            if(tmp1 == tmp2)
                            {
                                //On modifie le bgColor car le tchat doit être + foncé que le thème présent

                                Hls_To_Rgb_Tchat();

                                LigneEnCoursDeLecture = $"<entry key=\"chat.bgColor\">0x{BgColor.Substring(1)}</entry>";//Substring pour enlever le # de #123456 => 123456 

                            }
                        }
                        ListFile.Add(LigneEnCoursDeLecture);
                        LigneEnCoursDeLecture = sr.ReadLine();

                    }
                }

                File.Delete(FilePath);
                //ssss//StreamWriter rajoute une ligne vide à la fin du fichier colos.xml, c'est ce qui fait que le thème ne charge pas, trouver une solution
                using(StreamWriter StringWrite = File.CreateText(FilePath))
                {
                    foreach(string item in ListFile)
                    {
                        StringWrite.WriteLine(item);
                    }

                    StringWrite.WriteLine("</LangFile>");

                }
                return true;
            }
            //On créé le fichier puis on écrit

            return false;

        }

        //================================================================================================//
        //================================================================================================//
        //==============================Fonction d'action et de verification==============================//
        //================================================================================================//
        //================================================================================================//

        private void Browse_FolderSearch()
        {
            using(FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.RootFolder = Environment.SpecialFolder.ApplicationData;
                fbd.Description = "Selectionner le fichier";
                fbd.ShowNewFolderButton = true;
                DialogResult result = fbd.ShowDialog();

                if(result == DialogResult.OK)
                    Folder_Theme_Path = fbd.SelectedPath;
            }
        }
        //================================================================================================//
        private void Browse_File_ImageName()
        {//Ne pas oublier d'ajouter la référence de windows.forms et le using
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                DialogResult result = ofd.ShowDialog();
                if(result == DialogResult.OK)
                    File_config_Txt_Path = ofd.FileName;
            }
        }
        //================================================================================================//
        private void GoAppdataFolder()
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Dofus\ui\themes");
        }
        //================================================================================================//
        private void Move_File(string item)
        {
            string itemPath = Folder_Theme_Path + "\\" + item;
            bool IsValid = File.Exists(itemPath);
            if(IsValid)
            {
                File.Delete(itemPath);
            }

            //Vérification si l fichier existe, s'il n'existe pas, on ne peut pas le bouger
            itemPath = Path + "Nouveau thème\\" + item;

            IsValid = File.Exists(itemPath);

            itemPath = Folder_Theme_Path + "\\" + item;

            if(IsValid)
            {
                File.Move(Path + "Nouveau thème\\" + item, itemPath);
            }
        }
        //================================================================================================//
        private void Modify_All_Images()
        {
            //Pour permet au bgColor de se mettre à jour 
            Apercu();

            //Fonction qui va créer les dossiers en fonction des noms
            GF.Create_Folders(Path + "Nouveau thème\\", GF.Get_Paths_Without_NameFile(List_Files_Names));
            //On lit les noms d'images dans le constructeur
            foreach(string item in List_Files_Names)
            {
                ModifyOneImage(item, Folder_Theme_Path);
            }
            //Process.Start(Path + "Nouveau thème\\");
            foreach(string item in List_Files_Names)
            {
                Move_File(item);
            }
            Directory.Delete(Path + "Nouveau thème\\", true);

            //Changement du fond du tchat
            ModifyColorXml(Folder_Theme_Path + "\\colors.xml");

            Display_FMW();

            Send_FMW_Instance();
            
            GF.Play_Finish_Sound();

        }

        private void Send_FMW_Instance()
        {
            Messenger<FinishModificationWindow>.Instance.Send(Groups.ViewModels, FMW_Instance);
        }

        private void Display_FMW()
        {
            FMW_Instance = new FinishModificationWindow();
            FMW_Instance.Show();
        }

        //================================================================================================//
        private bool CanModifyAllImages()
        {
            return CountLoadedImage != ZeroImageCharged && (File_config_Txt_Path != null && File_config_Txt_Path != "") && (Folder_Theme_Path != null && Folder_Theme_Path != "");
        }
        //================================================================================================//
        private void Apercu()
        {
            //On essaie de modifier l'image qui est relié à la vue
            //Recréer une fonction juste pour l'apercu

            ModifyApercu();

        }
        //================================================================================================//
        private bool CanApercu()
        {

            return !(File_config_Txt_Path == null || File_config_Txt_Path == "");

        }
        //================================================================================================//
        private void Load_Files()
        {
            List_Files_Names = GF.Read_File_Content(File_config_Txt_Path);
            //Ajout du nombre d'images chargés dans la vue
            CountLoadedImage = (GF.Get_Number_Loaded_file_Into_folderPath(List_Files_Names, Folder_Theme_Path)).ToString();
        }
        //================================================================================================//
        private bool Can_Load_Files()
        {
            //le champ pour le champ File_config_Txt_Path ne peut pas être vide/null
            bool isValid1 = (File_config_Txt_Path != "");

            //il doit y avoir "config.txt" à la fin de "File_config_Txt_Path"
            bool isValid2 = File_config_Txt_Path.Length - 10 < 0 ? false : File_config_Txt_Path.Substring(File_config_Txt_Path.Length - 10, 10) == "config.txt";

            // Il faut que les images chargées soit != 0 et que le champ File_config_Txt_Path ne soit pas vide
            bool isValid3 = CountLoadedImage != ZeroImageCharged && !(File_config_Txt_Path == "");

            bool isValid4 = (Folder_Theme_Path != "");
            return ((isValid1 && isValid2) && isValid4) || (isValid3);

        }
        //================================================================================================//
        private void Delete_Image_Charged()
        {
            CountLoadedImage = "0";
            List_Files_Names.Clear();
        }
        //================================================================================================//
        private bool Can_Delete_Image_Charged()
        {
            return CountLoadedImage != ZeroImageCharged;
        }
        //================================================================================================//
        private void Close_Window()
        {
            GW.Close_Window(GW.Get_MainWindow_Instance());
        }

        #endregion
    }
}
