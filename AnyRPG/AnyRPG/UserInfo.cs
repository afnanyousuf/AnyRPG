using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnyRPG
{
    partial class UserInfo : Form
    {
        public UserInfo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
           
             
        }

        rangerCharacter Ranger;
        warriorCharacter Warrior;
        mageCharacter Mage;
        String Sgender;
        String Sclass;
        Player player;

        

        public Player CPlayer
        {
            get { return player; }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            bool gender;
            

            switch(comboBox2.SelectedIndex){

                case 0:
                    gender = true; //male
                    Sgender = "Male";
                    break;
                case 1:
                    gender = false;//female
                    Sgender = "Female";
                    break;
                default:
                    gender = true; //male
                    Sgender = "Male";
                    break;
                   


            }


            
            switch (comboBox1.SelectedIndex)
            {
                //warrior,ranger,mage

                case 0:
                    player = new warriorCharacter(textBox1.Text.ToString(), Sgender,"Warrior");
                    break;

                case 1:
                    player = new rangerCharacter(textBox1.Text.ToString(), Sgender,"Ranger");
                    break;
                case 2:
                    player = new mageCharacter(textBox1.Text.ToString(), Sgender,"Mage");
                    break;

          


            }
           

            this.Close();
            
            
            
            
            
            }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1)
            {
                pictureBox1.Image = ExcludeMe.FemaleWarrior;
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0)
            {
                pictureBox1.Image = ExcludeMe.MaleWarrior;
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == null)
            {
                pictureBox1.Image = ExcludeMe.MaleWarrior;
            }



            if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 1)
            {
                pictureBox1.Image = ExcludeMe.FemaleRanger;
            }
            else if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 0)
            {
                pictureBox1.Image = ExcludeMe.MaleRanger;
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == null)
            {
                pictureBox1.Image = ExcludeMe.MaleRanger;
            }

            if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 1)
            {
                pictureBox1.Image = ExcludeMe.FemaleMage;
            }
            else if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 0)
            {
                pictureBox1.Image = ExcludeMe.MaleMage;
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == null)
            {
                pictureBox1.Image = ExcludeMe.MaleMage;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 1)
            {
                pictureBox1.Image = ExcludeMe.FemaleWarrior;
            }
            else if(comboBox1.SelectedIndex == 0 && comboBox2.SelectedIndex == 0)
            {
                pictureBox1.Image = ExcludeMe.MaleWarrior;
            }



            if (comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 1)
            {
                pictureBox1.Image = ExcludeMe.FemaleRanger;
            }
            else if(comboBox1.SelectedIndex == 1 && comboBox2.SelectedIndex == 0)
            {
                pictureBox1.Image = ExcludeMe.MaleRanger;
            }

            if (comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 1)
            {
                pictureBox1.Image = ExcludeMe.FemaleMage;
            }
            else if(comboBox1.SelectedIndex == 2 && comboBox2.SelectedIndex == 0)
            {
                pictureBox1.Image = ExcludeMe.MaleMage;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            
           
        }




       

        

       


    }
 
}

