using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// B1.06 A model mappában lévő kódot elérhetővé tesszük
using oop.model;

namespace SquareAreaDistrictWPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // B1.07 Négyzet adattag
        private Square square;

        public MainWindow()
        {
            // B1.08 kivétel kezeléssel négyzet létrehozás
            int side = 1;
            try
            {
                // B1.08 Négyzet konsturktor kivételt dobhat, ha side<=0. Ezér van try-catch
                square = new Square(side);
            }
            catch (Exception e)
            { }
            InitializeComponent();
            // B1.09 Az oldal kezdőértéke a beviteli mezőbe
            // A TextBox vezérlő text (szöveg) mezőjében program induláskor belekerül az "1" kezdő érték
            // (tesztelje)
            txtSide.Text = side.ToString();
        }

        private void btnShowResult_Click(object sender, RoutedEventArgs e)
        {
            // B1.10 A gomb lenyomásakor kiolvassuk a felhasználó által beírt adatot
            // A felhasználó által megadott érték a TextBox vezérlő Text tulajdonságában van
            string sideString = txtSide.Text;

            // B1.11 A kiolvasott értéket valós számmá konvertáljuk
            double side = 0.0;
            // A TryParse true értéket ad vissza, ha sikerül a kovertálás, ezért használható elágazás
            // out azért kell, mert a side paraméter értéke a TryParse metódus meghívása során megváltozik
            if (!double.TryParse(sideString, out side))
            {
                // B1.12 Ha sikertelen a konvertálás hibaüzenetet jelenítünk meg
                // A TextBox beviteli mező keretét pirosra festjük
                txtSide.BorderBrush = Brushes.Red;
                // A felhasználónak megjelenítünk egy hibaüzenetet, ha ráviszi az egeret a TextBox-ra
                txtSide.ToolTip = "Nem megfelelő formátumú valós számot adott meg!";
            }
            else
            {
                // B1.13 Ha sikeres a konvertálás
                // 
                try
                {
                    // B1.14 A négyzet oldalát megváltoztatjuk, a kivételeket kezeljük
                    square.Side = side;
                }
                // B1.15 Kezeljük a saját kivételt
                catch (SqueraSideCannotBeNagativOrZero sse)
                {

                }
                // B1.15 Kezeljük a többi kivételt
                catch (Exception ex)
                {
                }
            }
        }
    }
}
