using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using Microsoft.Phone.Tasks;
using System.Xml.Linq;
using System.IO;
using System.IO.IsolatedStorage;

namespace FollowLiverpool
{
    public partial class MainPage : PhoneApplicationPage
    {
        int i;
        public MainPage()
        {
            doit();
            InitializeComponent();
            i = 1;
        }
        private void doit()
        {
            
            try
            {
                download();
                download2();
                download3();
                download4();
            }
            catch (Exception)
            {
                MessageBox.Show("Oops! Something went wrong.");
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            doit();
        }        
        void twitter_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (Microsoft.Phone.Net.NetworkInformation.NetworkInterface.NetworkInterfaceType == Microsoft.Phone.Net.NetworkInformation.NetworkInterfaceType.None)
            {
                if (i == 1)
                {
                    MessageBox.Show("Unable to download. No internet connection available!!");
                    i+=1;
                }
                return;
            }
            
            XElement xmlTweets = XElement.Parse(e.Result);
            lstTwitter1.ItemsSource = from tweet in xmlTweets.Descendants("status")
                                      select new tweets
                                          {
                                              ImageSource = tweet.Element("user").Element("profile_image_url").Value,
                                              Message = tweet.Element("text").Value
                                          };
            
        }


        void twitter2_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (Microsoft.Phone.Net.NetworkInformation.NetworkInterface.NetworkInterfaceType == Microsoft.Phone.Net.NetworkInformation.NetworkInterfaceType.None)
            {
                if (i == 1)
                {
                    MessageBox.Show("Unable to download. No internet connection available!!");
                    i += 1;
                }
                return;
            }

            XElement xmlTweets = XElement.Parse(e.Result);
            lstTwitter1.ItemsSource = from tweet in xmlTweets.Descendants("status")
                                      select new tweets
                                      {
                                          ImageSource = tweet.Element("user").Element("profile_image_url").Value,
                                          Message = tweet.Element("text").Value
                                      };
        }

        void twitter3_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (Microsoft.Phone.Net.NetworkInformation.NetworkInterface.NetworkInterfaceType == Microsoft.Phone.Net.NetworkInformation.NetworkInterfaceType.None)
            {
                if (i == 1)
                {
                    MessageBox.Show("Unable to download. No internet connection available!!");
                    i += 1;
                }
                return;
            }

            XElement xmlTweets = XElement.Parse(e.Result);
            lstTwitter1.ItemsSource = from tweet in xmlTweets.Descendants("status")
                                      select new tweets
                                      {
                                          ImageSource = tweet.Element("user").Element("profile_image_url").Value,
                                          Message = tweet.Element("text").Value
                                      };
        }

        void twitter4_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (Microsoft.Phone.Net.NetworkInformation.NetworkInterface.NetworkInterfaceType == Microsoft.Phone.Net.NetworkInformation.NetworkInterfaceType.None)
            {
                if (i == 1)
                {
                    MessageBox.Show("Unable to download. No internet connection available!!");
                    i += 1;
                }
                return;
            }

            XElement xmlTweets = XElement.Parse(e.Result);
            lstTwitter1.ItemsSource = from tweet in xmlTweets.Descendants("status")
                                      select new tweets
                                      {
                                          ImageSource = tweet.Element("user").Element("profile_image_url").Value,
                                          Message = tweet.Element("text").Value
                                      };
        }

        private void download()
        {

            WebClient twitter = new WebClient();
            twitter.DownloadStringCompleted += new DownloadStringCompletedEventHandler(twitter_DownloadStringCompleted);
            twitter.DownloadStringAsync(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=liverpool"));
        }
        private void download2()
        {
            WebClient twitter2 = new WebClient();
            twitter2.DownloadStringCompleted += new DownloadStringCompletedEventHandler(twitter2_DownloadStringCompleted);
            twitter2.DownloadStringAsync(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=rodgers_brendan"));
        }
        private void download3()
        {   

            WebClient twitter3 = new WebClient();
            twitter3.DownloadStringCompleted += new DownloadStringCompletedEventHandler(twitter3_DownloadStringCompleted);
            twitter3.DownloadStringAsync(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=sgf08"));
        }
        private void download4()
        {

            WebClient twitter4 = new WebClient();
            twitter4.DownloadStringCompleted += new DownloadStringCompletedEventHandler(twitter4_DownloadStringCompleted);
            twitter4.DownloadStringAsync(new Uri("http://api.twitter.com/1/statuses/user_timeline.xml?screen_name=luis16suarez"));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            download3();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "https://mobile.www.twitter.com/sgf08";
            task.Show();
        }


        private void button3_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "https://mobile.www.twitter.com/rodgers_brendan";
            task.Show();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            download2();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            download();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "https://mobile.www.twitter.com/liverpool";
            task.Show();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "https://mobile.www.twitter.com/luis16suarez";
            task.Show();
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            download4();
        }

        private void appbar_button1_Click(object sender, EventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "https://www.facebook.com/pages/Argon/157417934352483";
            task.Show();
        }
    }
}