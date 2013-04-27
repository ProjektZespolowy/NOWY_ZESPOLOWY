using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
using AForge.Imaging.ComplexFilters;

namespace Snapshot_Maker
{
    public partial class MainForm : Form
    {
        private FilterInfoCollection urzadzenia;
        private VideoCaptureDevice kamera;
        private VideoCapabilities[] parametry_video;
        private VideoCapabilities[] parametry_photo;
        private SnapshotForm snapshotForm = null;
        private RecognizeForm recognizeform = null;

        private Point[] bolce = new Point[6];

        public MainForm( )
        {
            InitializeComponent( );
        }

        // Main form is loaded
        private void MainForm_Load( object sender, EventArgs e )
        {
            urzadzenia = new FilterInfoCollection( FilterCategory.VideoInputDevice );
            
            if ( urzadzenia.Count != 0 )
            {
                foreach ( FilterInfo device in urzadzenia )
                {
                    devicesCombo.Items.Add( device.Name );
                }
            }
            else
            {
                devicesCombo.Items.Add( "Brak KAMERY !" );
            }
            devicesCombo.SelectedIndex = 0;


            EnableConnectionControls( true );
            //checkBox_calibrated.Enabled = false;
        }

        private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            Disconnect( );
        }

        private void EnableConnectionControls( bool enable )
        {
            devicesCombo.Enabled = enable;
            videoResolutionsCombo.Enabled = enable;
            snapshotResolutionsCombo.Enabled = enable;
            connectButton.Enabled = enable;
            disconnectButton.Enabled = !enable;
            triggerButton.Enabled = ( !enable ) && ( parametry_photo.Length != 0 );
            button_algorytm.Enabled = false;
        }

        // New video device is selected
        private void devicesCombo_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( urzadzenia.Count != 0 )
            {
                kamera = new VideoCaptureDevice( urzadzenia[devicesCombo.SelectedIndex].MonikerString );
                EnumeratedSupportedFrameSizes( kamera );
            }
        }

        // Collect supported video and snapshot sizes
        private void EnumeratedSupportedFrameSizes( VideoCaptureDevice kamera )
        {
            videoResolutionsCombo.Items.Clear( );
            snapshotResolutionsCombo.Items.Clear( );

            parametry_video = kamera.VideoCapabilities;
            parametry_photo = kamera.SnapshotCapabilities;

            foreach ( VideoCapabilities capabilty in parametry_video )
            {
                if ( !videoResolutionsCombo.Items.Contains( capabilty.FrameSize ) )
                {
                    videoResolutionsCombo.Items.Add( capabilty.FrameSize );
                }
            }

            foreach ( VideoCapabilities capabilty in parametry_photo )
            {
                if ( !snapshotResolutionsCombo.Items.Contains( capabilty.FrameSize ) )
                {
                    snapshotResolutionsCombo.Items.Add( capabilty.FrameSize );
                }
            }

            if ( parametry_video.Length == 0 )
            {
                videoResolutionsCombo.Items.Add( "Not supported" );
            }
            if ( parametry_photo.Length == 0 )
            {
                snapshotResolutionsCombo.Items.Add( "Not supported" );
            }

            videoResolutionsCombo.SelectedIndex = 0;
            snapshotResolutionsCombo.SelectedIndex = 0;
            
        }

        // On "Connect" button clicked
        private void connectButton_Click( object sender, EventArgs e )
        {
            if ( kamera != null )
            {
                if ( ( parametry_video != null ) && ( parametry_video.Length != 0 ) )
                {
                    kamera.DesiredFrameSize = (Size) videoResolutionsCombo.SelectedItem;
                    kamera.DesiredFrameRate = 50;
                }

                if ( ( parametry_photo != null ) && ( parametry_photo.Length != 0 ) )
                {
                    kamera.ProvideSnapshots = true;
                    kamera.DesiredSnapshotSize = (Size) snapshotResolutionsCombo.SelectedItem;
                    kamera.SnapshotFrame += new NewFrameEventHandler( videoDevice_SnapshotFrame );
                }

                EnableConnectionControls( false );

                videoSourcePlayer.VideoSource = kamera;
                videoSourcePlayer.Start( );
            }
        }

        // On "Disconnect" button clicked
        private void disconnectButton_Click( object sender, EventArgs e )
        {
            Disconnect( );
        }

        // Disconnect from video device
        private void Disconnect( )
        {
            if ( videoSourcePlayer.VideoSource != null )
            {
                // stop video device
                videoSourcePlayer.SignalToStop( );
                videoSourcePlayer.WaitForStop( );
                videoSourcePlayer.VideoSource = null;

                if ( kamera.ProvideSnapshots )
                {
                    kamera.SnapshotFrame -= new NewFrameEventHandler( videoDevice_SnapshotFrame );
                }

                EnableConnectionControls( true );
            }
        }

        // Simulate snapshot trigger
        private void triggerButton_Click( object sender, EventArgs e )
        {
            if ( ( kamera != null ) && ( kamera.ProvideSnapshots ) )
            {
                kamera.SimulateTrigger( );
            }
        }

        // New snapshot frame is available
        private void videoDevice_SnapshotFrame( object sender, NewFrameEventArgs eventArgs )
        {
            Console.WriteLine( eventArgs.Frame.Size );
            ShowSnapshot( (Bitmap) eventArgs.Frame.Clone( ) );
        }

        private void ShowSnapshot( Bitmap snapshot )
        {
            if (checkBox_calibrated.Checked == false)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<Bitmap>(ShowSnapshot), snapshot);
                }
                else
                {
                    if (snapshotForm == null)
                    {
                        snapshotForm = new SnapshotForm();
                        snapshotForm.FormClosed += new FormClosedEventHandler(snapshotForm_FormClosed);
                        snapshotForm.Show();
                    }

                    snapshotForm.SetImage(snapshot);
                }
            }
            else // rozpoznajemy
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<Bitmap>(ShowSnapshot), snapshot);
                }
                else
                {
                    if (snapshotForm == null)
                    {
                        recognizeform = new RecognizeForm();
                        recognizeform.FormClosed += new FormClosedEventHandler(recognizeform_FormClosed);
                        recognizeform.Show();
                    }

                    recognizeform.SetImage(snapshot);
                }
            }
        }

        private void snapshotForm_FormClosed( object sender, FormClosedEventArgs e )
        {
            snapshotForm = null;
            checkBox_calibrated.Checked = true;
        }

        private void recognizeform_FormClosed(object sender, FormClosedEventArgs e)
        {
            recognizeform = null;
        }

        private void button_algorytm_Click(object sender, EventArgs e)
        {
            triggerButton_Click(null, null);
        }

        private void checkBox_calibrated_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_calibrated.Checked == true)
            {
                button_algorytm.Enabled = true;
                triggerButton.Enabled = false;
            }
            else
            {
                triggerButton.Enabled = true;
                button_algorytm.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recognizeform = new RecognizeForm();
            recognizeform.Show();
        }
    }
}
