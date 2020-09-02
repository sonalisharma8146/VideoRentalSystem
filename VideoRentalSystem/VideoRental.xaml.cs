using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VideoRentalSystem
{
    /// <summary>
    /// Interaction logic for VideoRental.xaml
    /// </summary>
    public partial class VideoRental : Window
    {
        
        DatabaseClass Obj_data = new DatabaseClass();
        public int CustID, RMID;
        public int MovieID, Copies;

        public VideoRental()
        {
            this.InitializeComponent();
            base.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
        }



        private void Rating_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //Tab_Cust_Loaded() used to load the customer data from the table to datagrid. 
        private void Tab_Cust_Loaded(object sender, RoutedEventArgs e)
        {
            CustomerData.ItemsSource = Obj_data.CustData().DefaultView;
        }

        //SelectCustDataRow() method used to select customer data in a datagrid by mouse double click in it,*for any update or delete it..
        private void SelectCustDataRow(object sender, MouseButtonEventArgs e)
        {
            DataRowView view = (DataRowView)CustomerData.SelectedItems[0];
            CustID = Convert.ToInt32(view["CustID"]);
            CustomerID_Txtbox.Text = Convert.ToString(view["CustID"]);
            FirstName_TxtBox.Text = Convert.ToString(view["FirstName"]);
            LastName_TxtBox.Text = Convert.ToString(view["LastName"]);
            Address_TxtBox.Text = Convert.ToString(view["Address"]);
            Phone_TxtBox.Text = Convert.ToString(view["Phone"]);
            CustomerData.ItemsSource = Obj_data.CustData().DefaultView;
        }

        //Add_Cust_Btn_Click() method used to add the new customer in table for movie rent
        private void Add_Cust_Btn_Click(object sender, RoutedEventArgs e)
        {

            if (((FirstName_TxtBox.Text != "") && ((LastName_TxtBox.Text != "") && (Address_TxtBox.Text != ""))) && Phone_TxtBox.Text != "")
            {
                Obj_data.Add_cust(FirstName_TxtBox.Text, LastName_TxtBox.Text, Address_TxtBox.Text, Phone_TxtBox.Text);

                //if the customer added message will be pop up 
                MessageBox.Show("Customer Added");
                CustomerData.ItemsSource = Obj_data.CustData().DefaultView;
                FirstName_TxtBox.Text = "";
                LastName_TxtBox.Text = "";
                Address_TxtBox.Text = "";
                Phone_TxtBox.Text = "";
                MovieID_Txtbox.Text = "";
                DateRented_Txtbox.Text = "";
                DateReturned_Txtbox.Text = "";

            }

        }

        //Update_Cust_Btn_Click() this method help to update the changes in a customer data like change the address or phone.
        private void Update_Cust_Btn_Click(object sender, RoutedEventArgs e)
        {
            Obj_data.Update_cust(CustID, FirstName_TxtBox.Text, LastName_TxtBox.Text, Address_TxtBox.Text, Convert.ToInt32(Phone_TxtBox.Text));

            //if the changes are updated message will be updated
            MessageBox.Show("Customer Updated");
            CustomerData.ItemsSource = Obj_data.CustData().DefaultView;
            FirstName_TxtBox.Text = "";
            LastName_TxtBox.Text = "";
            Address_TxtBox.Text = "";
            Phone_TxtBox.Text = "";
            CustomerID_Txtbox.Text = "";
            MovieID_Txtbox.Text = "";
            DateRented_Txtbox.Text = "";
            DateReturned_Txtbox.Text = "";

        }
        //Delete_Cust_Btn_Click() this button help to delete the customer from the table
        private void Delete_Cust_Btn_Click(object sender, RoutedEventArgs e)
        {
            //before the Customer deleted,pop up message of yes or  no will be shown for the surity.
            if (MessageBox.Show("Are you sure you want to delete the Customer?", "User", MessageBoxButton.YesNo).ToString() == "Yes")
            {
               Obj_data.Delete_cust(CustID);
                CustomerData.ItemsSource = Obj_data.CustData().DefaultView;
                FirstName_TxtBox.Text = "";
                LastName_TxtBox.Text = "";
                Address_TxtBox.Text = "";
                Phone_TxtBox.Text = "";
                CustomerID_Txtbox.Text = "";
                MovieID_Txtbox.Text = "";
                DateRented_Txtbox.Text = "";
                DateReturned_Txtbox.Text = "";

            }

        }


        //Tab_Movi_Loaded() used to load the Movies data from the table to datagrid.
        private void Tab_Movi_Loaded(object sender, RoutedEventArgs e)
        {
            VideoData.ItemsSource = Obj_data.MoviData().DefaultView;
        }

        //SelectMoviDataRow() method used to select movie data in a datagrid by mouse double click in it,*for any update or delete it.
        private void SelectMoviDataRow(object sender, MouseButtonEventArgs e)
        {
            DataRowView view = (DataRowView)VideoData.SelectedItems[0];
            MovieID = Convert.ToInt32(view["MovieID"]);
            Copies = Convert.ToInt32(view["Copies"]);
           
            MovieID_Txtbox.Text = Convert.ToString(view["MovieID"]);
            Rating_TxtBox.Text = Convert.ToString(view["Rating"]);
            Title_TxtBox.Text = Convert.ToString(view["Title"]);
            Year_TxtBox.Text = Convert.ToString(view["Year"]);
            Copies_TxtBox.Text = Convert.ToString(view["Copies"]);
            Plot_TxtBox.Text = Convert.ToString(view["Plot"]);
            Genre_TxtBox.Text = Convert.ToString(view["Genre"]);
            DateRented_Txtbox.Text = DateTime.Now.ToString("dd-MM-yyyy");
            VideoData.ItemsSource = Obj_data.MoviData().DefaultView;
        }

        //Add_Movie_Btn_Click() method used to add the new movies in table
        private void Add_Movie_Btn_Click(object sender, RoutedEventArgs e)
        {

            if (((Rating_TxtBox.Text != "") && ((Title_TxtBox.Text != "") && (Year_TxtBox.Text != ""))) && ((Copies_TxtBox.Text != "") && ((Plot_TxtBox.Text != "") && (Genre_TxtBox.Text != ""))))
            {
                Obj_data.Add_movi(Rating_TxtBox.Text, Title_TxtBox.Text, Year_TxtBox.Text, Copies_TxtBox.Text, Plot_TxtBox.Text, Genre_TxtBox.Text);

               //the message will be pop up after the movie added.
                MessageBox.Show("Movie Added");
                VideoData.ItemsSource = Obj_data.MoviData().DefaultView;
                Rating_TxtBox.Text = "";
                Title_TxtBox.Text = "";
                Year_TxtBox.Text = "";
                Copies_TxtBox.Text = "";
                Plot_TxtBox.Text = "";
                Genre_TxtBox.Text = "";
                CustomerID_Txtbox.Text = "";
                DateRented_Txtbox.Text = "";
                DateReturned_Txtbox.Text = "";

            }
        }

        //Update_Movie_Btn_Click() this method help to update the changes in a movie data.
        private void Update_Movie_Btn_Click(object sender, RoutedEventArgs e)
        {
            Obj_data.Update_movi(MovieID, Rating_TxtBox.Text, Title_TxtBox.Text, Year_TxtBox.Text, Copies_TxtBox.Text, Plot_TxtBox.Text, Genre_TxtBox.Text);
           
            //the message will be pop up after the movie updated.
            MessageBox.Show("Movie Updated");
            VideoData.ItemsSource = Obj_data.MoviData().DefaultView;
            Rating_TxtBox.Text = "";
            Title_TxtBox.Text = "";
            Year_TxtBox.Text = "";
            Copies_TxtBox.Text = "";
            Plot_TxtBox.Text = "";
            Genre_TxtBox.Text = "";
            MovieID_Txtbox.Text = "";
            CustomerID_Txtbox.Text = "";
            DateRented_Txtbox.Text = "";
            DateReturned_Txtbox.Text = "";

        }

        //Delete_Movie_Btn_Click() this button help to delete the movies from the table
       private void Delete_Movie_Btn_Click(object sender, RoutedEventArgs e)
        {
            //before the movie deleted,pop up message of yes or  no will be shown for the surity.
            if (MessageBox.Show("Are you sure you want to delete the Movie?", "User", MessageBoxButton.YesNo).ToString() == "Yes")
            {
                Obj_data.Delete_movi(MovieID);
                VideoData.ItemsSource = Obj_data.MoviData().DefaultView;
                Rating_TxtBox.Text = "";
                Title_TxtBox.Text = "";
                Year_TxtBox.Text = "";
                Copies_TxtBox.Text = "";
                Plot_TxtBox.Text = "";
                Genre_TxtBox.Text = "";
                MovieID_Txtbox.Text = "";
                CustomerID_Txtbox.Text = "";
                DateRented_Txtbox.Text = "";
                DateReturned_Txtbox.Text = "";

            }

        }

        //Tab_Rent_Loaded() used to load the RentalMovies data from the table to datagrid.
        private void Tab_Rent_Loaded(object sender, RoutedEventArgs e)
        {
            RentalData.ItemsSource = Obj_data.RentData().DefaultView;
        }


        //SelectRentDataRow() method used to select RentalMovies data in a datagrid by mouse double click in it,*for any update or delete it..
        private void SelectRentDataRow(object sender, MouseButtonEventArgs e)
        {
             
            DataRowView view = (DataRowView)RentalData.SelectedItems[0];
            RMID = Convert.ToInt32(view["RMID"]);
            if (Obj_data.ReturnDateValue(RMID) == true)
            {
                MovieID = Convert.ToInt32(view["MovieIDFK"]);
                MovieID_Txtbox.Text = Convert.ToString(view["MovieIDFK"]);
                CustomerID_Txtbox.Text = Convert.ToString(view["CustIDFK"]);
                DateRented_Txtbox.Text = Convert.ToString(view["DateRented"]);
                DateReturned_Txtbox.Text = DateTime.Now.ToString("dd-MM-yyyy");
                RentalData.ItemsSource = Obj_data.RentData().DefaultView;
            }
            else
            {

            //if customer has already returned the movie then this message will pop up
                MessageBox.Show("Customer has already returned the movie");
            }
        }

        //Issue_Rent_Btn_Click() used to issue the movie to the customer by choosing CustID and MovieID from the tables.
        private void Issue_Rent_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Copies != 0)
            {
                if (((MovieID_Txtbox.Text != "") && ((CustomerID_Txtbox.Text != "") && (DateRented_Txtbox.Text != ""))))
                {
                    Obj_data.Issue_Movi(Convert.ToInt32(MovieID_Txtbox.Text), Convert.ToInt32(CustomerID_Txtbox.Text), Convert.ToDateTime(DateRented_Txtbox.Text), Copies);

                    //if the movies is in stock then movie will be issued for the rent.
                    MessageBox.Show("Movie Issued");
                    RentalData.ItemsSource = Obj_data.RentData().DefaultView;
                    VideoData.ItemsSource = Obj_data.MoviData().DefaultView;
                    CustomerData.ItemsSource = Obj_data.CustData().DefaultView;
                    Rating_TxtBox.Text = "";
                    Title_TxtBox.Text = "";
                    Year_TxtBox.Text = "";
                    Copies_TxtBox.Text = "";
                    Plot_TxtBox.Text = "";
                    Genre_TxtBox.Text = "";
                    FirstName_TxtBox.Text = "";
                    LastName_TxtBox.Text = "";
                    Address_TxtBox.Text = "";
                    Phone_TxtBox.Text = "";
                    CustomerID_Txtbox.Text = "";
                    MovieID_Txtbox.Text = "";
                    DateRented_Txtbox.Text = "";
                    DateReturned_Txtbox.Text = "";  
                }
            }
            else
            {
                //if all the movies have been rented then pop up message will be shown that movie is out of stock. 
                MessageBox.Show("This Movie is out of stock.");
            }
        }

        //Return_Rent_Btn_Click() used to return the rented movie from RentalMovies table.
        private void Return_Rent_Btn_Click(object sender, RoutedEventArgs e)
        {
            Obj_data.Return_Movi(RMID,MovieID, Convert.ToDateTime(DateRented_Txtbox.Text), Convert.ToDateTime(DateReturned_Txtbox.Text), Copies);
            RentalData.ItemsSource = Obj_data.RentData().DefaultView;
            VideoData.ItemsSource = Obj_data.MoviData().DefaultView;
            CustomerData.ItemsSource = Obj_data.CustData().DefaultView;
            MovieID_Txtbox.Text = "";
            CustomerID_Txtbox.Text = "";
            Rating_TxtBox.Text = "";
            Title_TxtBox.Text = "";
            Year_TxtBox.Text = "";
            Copies_TxtBox.Text = "";
            Plot_TxtBox.Text = "";
            Genre_TxtBox.Text = "";
            FirstName_TxtBox.Text = "";
            LastName_TxtBox.Text = "";
            Address_TxtBox.Text = "";
            Phone_TxtBox.Text = "";
            DateReturned_Txtbox.Text = "";
            DateRented_Txtbox.Text = "";
            
        }

      
        //TopMovie_Btn_Click() help to sort the  most rented movies.
        private void TopMovie_Btn_Click(object sender, RoutedEventArgs e)
        {
            Obj_data.Top_Movie();

        }

        //AllRented_Btn_Click() used to load only Rented out movies data from the table to datagrid.
        private void RentedOutMovi_Btn_Click(object sender, RoutedEventArgs e)
        {
            RentalData.ItemsSource = Obj_data.RentoutData().DefaultView;
        }

        //AllRented_Btn_Click() used to load the RentalMovies data from the table to datagrid.
        private void AllRented_Btn_Click(object sender, RoutedEventArgs e)
        {
            RentalData.ItemsSource = Obj_data.RentData().DefaultView;
        }

        //BestBuyer_Btn_Click() help to sort the number 1 customer who rented the most movies.
        private void BestBuyer_Btn_Click(object sender, RoutedEventArgs e)
        {
            Obj_data.Best_Buyer();
        }

        //Exit_Button_Click will help to close the whole program.
        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

    } 
    }
