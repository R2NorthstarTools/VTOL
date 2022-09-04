using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titanfall2_SkinTool.Titanfall2.WeaponData.Default.SubmachineGun;

namespace Titanfall2_SkinTool.Titanfall2.WeaponData
{
    public class WeaponDataControl
    {
        //这里有待优化
        public string[,] FilePath = new string[1, 4];
        //col，nml，gls，spc，ilm，ao，cav
        //2为2048x2048,1为1024x1024,0为512x512
        public WeaponDataControl(string WeaponName, int imagecheck)
        {
            //单独为专注和XO16的弹夹写判断emmm。。。。
            if (WeaponName.Contains("Devotion_clip") && WeaponName.Contains("Default"))
            {
                Default.LightMachineGun.Devotion devotion_clip = new Default.LightMachineGun.Devotion();
                if (WeaponName.Contains("col"))
                {
                    int i = 0;
                    FilePath[0, i] = devotion_clip.Devotion_clip_col[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_col[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_col[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_col[imagecheck].seeklength);
                }
                if (WeaponName.Contains("nml"))
                {
                    int i = 0;
                    FilePath[0, i] = devotion_clip.Devotion_clip_nml[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_nml[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_nml[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_nml[imagecheck].seeklength);
                }
                if (WeaponName.Contains("gls"))
                {
                    int i = 0;
                    FilePath[0, i] = devotion_clip.Devotion_clip_gls[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_gls[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_gls[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_gls[imagecheck].seeklength);
                }
                if (WeaponName.Contains("spc"))
                {
                    int i = 0;
                    FilePath[0, i] = devotion_clip.Devotion_clip_spc[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_spc[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_spc[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_spc[imagecheck].seeklength);
                }
                if (WeaponName.Contains("ilm"))
                {
                    int i = 0;
                    FilePath[0, i] = devotion_clip.Devotion_clip_ilm[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_ilm[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_ilm[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_ilm[imagecheck].seeklength);
                }
                if (WeaponName.Contains("ao"))
                {
                    int i = 0;
                    FilePath[0, i] = devotion_clip.Devotion_clip_ao[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_ao[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_ao[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_ao[imagecheck].seeklength);
                }
                if (WeaponName.Contains("cav"))
                {
                    int i = 0;
                    FilePath[0, i] = devotion_clip.Devotion_clip_cav[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_cav[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_cav[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(devotion_clip.Devotion_clip_cav[imagecheck].seeklength);
                }
                return;
            }
            if (WeaponName.Contains("XO16_clip") && WeaponName.Contains("Default"))
            {
                Default.Titan.XO16 XO16_clip = new Default.Titan.XO16();
                if (WeaponName.Contains("col"))
                {
                    int i = 0;
                    FilePath[0, i] = XO16_clip.XO16_clip_col[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_col[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_col[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_col[imagecheck].seeklength);
                }
                if (WeaponName.Contains("nml"))
                {
                    int i = 0;
                    FilePath[0, i] = XO16_clip.XO16_clip_nml[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_nml[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_nml[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_nml[imagecheck].seeklength);
                }
                if (WeaponName.Contains("gls"))
                {
                    int i = 0;
                    FilePath[0, i] = XO16_clip.XO16_clip_gls[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_gls[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_gls[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_gls[imagecheck].seeklength);
                }
                if (WeaponName.Contains("spc"))
                {
                    int i = 0;
                    FilePath[0, i] = XO16_clip.XO16_clip_spc[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_spc[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_spc[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_spc[imagecheck].seeklength);
                }
                if (WeaponName.Contains("ilm"))
                {
                    int i = 0;
                    FilePath[0, i] = XO16_clip.XO16_clip_ilm[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_ilm[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_ilm[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_ilm[imagecheck].seeklength);
                }
                if (WeaponName.Contains("ao"))
                {
                    int i = 0;
                    FilePath[0, i] = XO16_clip.XO16_clip_ao[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_ao[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_ao[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_ao[imagecheck].seeklength);
                }
                if (WeaponName.Contains("cav"))
                {
                    int i = 0;
                    FilePath[0, i] = XO16_clip.XO16_clip_cav[imagecheck].name;
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_cav[imagecheck].seek);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_cav[imagecheck].length);
                    i++;
                    FilePath[0, i] = Convert.ToString(XO16_clip.XO16_clip_cav[imagecheck].seeklength);
                }
                return;
            }
            string[] name=VTOL.MainWindow.GetTextureName(WeaponName);
            string str = name[0];
            string s = name[1];
            if (str.Contains("Default"))
            {
                switch (s)
                {
                    //冲锋枪
                    case "CAR":
                        Default.SubmachineGun.CAR car = new Default.SubmachineGun.CAR();
                        //col，nml，gls，spc，ilm，ao，cav
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = car.CAR_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = car.CAR_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = car.CAR_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = car.CAR_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = car.CAR_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = car.CAR_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = car.CAR_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(car.CAR_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Alternator":
                        Default.SubmachineGun.Alternator alternator = new Default.SubmachineGun.Alternator();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = alternator.Alternator_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = alternator.Alternator_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = alternator.Alternator_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = alternator.Alternator_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_spc[imagecheck].seeklength);
                        }
                        //转换者没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = alternator.Alternator_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = alternator.Alternator_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(alternator.Alternator_cav[imagecheck].seeklength);
                        }
                        break;
                    case "R97":
                        Default.SubmachineGun.R97 r97 = new Default.SubmachineGun.R97();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = r97.R97_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = r97.R97_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = r97.R97_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = r97.R97_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = r97.R97_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = r97.R97_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = r97.R97_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r97.R97_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Volt":
                        Default.SubmachineGun.Volt volt = new Default.SubmachineGun.Volt();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = volt.Volt_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = volt.Volt_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = volt.Volt_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = volt.Volt_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = volt.Volt_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = volt.Volt_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = volt.Volt_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(volt.Volt_cav[imagecheck].seeklength);
                        }
                        break;
                    
                    //狙击步枪
                    case "DoubleTake":
                        Default.Sniper.DoubleTake doubletake = new Default.Sniper.DoubleTake();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = doubletake.DoubleTake_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = doubletake.DoubleTake_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = doubletake.DoubleTake_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = doubletake.DoubleTake_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_spc[imagecheck].seeklength);
                        }
                        //双击没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = doubletake.DoubleTake_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = doubletake.DoubleTake_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(doubletake.DoubleTake_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Kraber":
                        Default.Sniper.Kraber kraber = new Default.Sniper.Kraber();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = kraber.Kraber_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = kraber.Kraber_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = kraber.Kraber_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = kraber.Kraber_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = kraber.Kraber_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = kraber.Kraber_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = kraber.Kraber_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(kraber.Kraber_cav[imagecheck].seeklength);
                        }
                        break;
                    case "LongbowDMR":
                        Default.Sniper.LongbowDMR longbowdmr = new Default.Sniper.LongbowDMR();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = longbowdmr.LongbowDMR_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = longbowdmr.LongbowDMR_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = longbowdmr.LongbowDMR_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = longbowdmr.LongbowDMR_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_spc[imagecheck].seeklength);
                        }
                        //DMR没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = longbowdmr.LongbowDMR_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = longbowdmr.LongbowDMR_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(longbowdmr.LongbowDMR_cav[imagecheck].seeklength);
                        }
                        break;

                    //散弹枪
                    case "EVA8":
                        Default.Shotgun.EVA8 eva8 = new Default.Shotgun.EVA8();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = eva8.EVA8_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = eva8.EVA8_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = eva8.EVA8_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = eva8.EVA8_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = eva8.EVA8_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = eva8.EVA8_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = eva8.EVA8_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(eva8.EVA8_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Mastiff":
                        Default.Shotgun.Mastiff mastiff = new Default.Shotgun.Mastiff();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = mastiff.Mastiff_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = mastiff.Mastiff_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = mastiff.Mastiff_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = mastiff.Mastiff_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = mastiff.Mastiff_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = mastiff.Mastiff_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = mastiff.Mastiff_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mastiff.Mastiff_cav[imagecheck].seeklength);
                        }
                        break;

                    //手枪类只有两种分辨率，1024和512
                    case "Mozambique":
                        Default.Pistol.Mozambique mozambique = new Default.Pistol.Mozambique();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = mozambique.Mozambique_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = mozambique.Mozambique_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = mozambique.Mozambique_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = mozambique.Mozambique_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_spc[imagecheck].seeklength);
                        }
                        //莫三比克没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = mozambique.Mozambique_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = mozambique.Mozambique_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mozambique.Mozambique_cav[imagecheck].seeklength);
                        }
                        break;
                    case "P2016":
                        Default.Pistol.P2016 p2016 = new Default.Pistol.P2016();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = p2016.P2016_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = p2016.P2016_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = p2016.P2016_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = p2016.P2016_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = p2016.P2016_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = p2016.P2016_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = p2016.P2016_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(p2016.P2016_cav[imagecheck].seeklength);
                        }
                        break;
                    case "RE45":
                        Default.Pistol.RE45 re45 = new Default.Pistol.RE45();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = re45.RE45_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = re45.RE45_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = re45.RE45_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = re45.RE45_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = re45.RE45_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_ilm[imagecheck].seeklength);
                        }//RE45只有一个分辨率.....也许以后会有BUG？
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = re45.RE45_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = re45.RE45_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(re45.RE45_cav[imagecheck].seeklength);
                        }
                        break;
                    case "SmartPistol":
                        Default.Pistol.SmartPistol smartpistol = new Default.Pistol.SmartPistol();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = smartpistol.SmartPistol_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = smartpistol.SmartPistol_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = smartpistol.SmartPistol_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = smartpistol.SmartPistol_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = smartpistol.SmartPistol_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = smartpistol.SmartPistol_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = smartpistol.SmartPistol_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smartpistol.SmartPistol_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Wingman":
                        Default.Pistol.Wingman wingman = new Default.Pistol.Wingman();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingman.Wingman_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingman.Wingman_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingman.Wingman_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingman.Wingman_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingman.Wingman_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingman.Wingman_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingman.Wingman_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingman.Wingman_cav[imagecheck].seeklength);
                        }
                        break;
                    case "WingmanElite":
                        Default.Pistol.WingmanElite wingmanelite = new Default.Pistol.WingmanElite();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingmanelite.WingmanElite_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingmanelite.WingmanElite_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingmanelite.WingmanElite_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingmanelite.WingmanElite_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingmanelite.WingmanElite_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingmanelite.WingmanElite_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = wingmanelite.WingmanElite_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(wingmanelite.WingmanElite_cav[imagecheck].seeklength);
                        }
                        break;
                    //手枪类结束

                    //武器附件只有两种分辨率，1024和512
                    case "AcogSight":
                        Default.Attachment.AcogSight acogsight = new Default.Attachment.AcogSight();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = acogsight.AcogSight_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = acogsight.AcogSight_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = acogsight.AcogSight_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = acogsight.AcogSight_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_spc[imagecheck].seeklength);
                        }
                        //AcogSight没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = acogsight.AcogSight_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = acogsight.AcogSight_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(acogsight.AcogSight_cav[imagecheck].seeklength);
                        }
                        break;
                    case "AogSight":
                        Default.Attachment.AogSight aogsight = new Default.Attachment.AogSight();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = aogsight.AogSight_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = aogsight.AogSight_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = aogsight.AogSight_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = aogsight.AogSight_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_spc[imagecheck].seeklength);
                        }
                        //AogSight没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = aogsight.AogSight_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = aogsight.AogSight_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(aogsight.AogSight_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Hcog":
                        Default.Attachment.Hcog hcog = new Default.Attachment.Hcog();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = hcog.Hcog_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = hcog.Hcog_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = hcog.Hcog_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = hcog.Hcog_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = hcog.Hcog_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = hcog.Hcog_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = hcog.Hcog_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hcog.Hcog_cav[imagecheck].seeklength);
                        }
                        break;
                    case "HoloReflexSight":
                        Default.Attachment.HoloReflexSight holoreflexsight = new Default.Attachment.HoloReflexSight();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = holoreflexsight.HoloReflexSight_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = holoreflexsight.HoloReflexSight_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = holoreflexsight.HoloReflexSight_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = holoreflexsight.HoloReflexSight_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_spc[imagecheck].seeklength);
                        }
						//HoloReflexSight没有ilm,ao,cav地图
/*
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = holoreflexsight.HoloReflexSight_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = holoreflexsight.HoloReflexSight_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = holoreflexsight.HoloReflexSight_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(holoreflexsight.HoloReflexSight_cav[imagecheck].seeklength);
                        }
*/
                        break;
                    //ProScreen只有512分辨率纹理
                    case "ProScreen":
                        Default.Attachment.ProScreen proscreen = new Default.Attachment.ProScreen();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = proscreen.ProScreen_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = proscreen.ProScreen_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = proscreen.ProScreen_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = proscreen.ProScreen_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = proscreen.ProScreen_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = proscreen.ProScreen_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = proscreen.ProScreen_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(proscreen.ProScreen_cav[imagecheck].seeklength);
                        }
                        break;
                    case "SniperScope":
                        Default.Attachment.SniperScope sniperscope = new Default.Attachment.SniperScope();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = sniperscope.SniperScope_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = sniperscope.SniperScope_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = sniperscope.SniperScope_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = sniperscope.SniperScope_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_spc[imagecheck].seeklength);
                        }
                        //SniperScope没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = sniperscope.SniperScope_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = sniperscope.SniperScope_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscope.SniperScope_cav[imagecheck].seeklength);
                        }
                        break;
                    case "SniperScopeX4":
                        Default.Attachment.SniperScopeX4 sniperscopex4 = new Default.Attachment.SniperScopeX4();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = sniperscopex4.SniperScopeX4_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = sniperscopex4.SniperScopeX4_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = sniperscopex4.SniperScopeX4_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = sniperscopex4.SniperScopeX4_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_spc[imagecheck].seeklength);
                        }
                        //SniperScopeX4没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = sniperscopex4.SniperScopeX4_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = sniperscopex4.SniperScopeX4_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sniperscopex4.SniperScopeX4_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Supressor":
                        Default.Attachment.Supressor supressor = new Default.Attachment.Supressor();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = supressor.Supressor_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = supressor.Supressor_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = supressor.Supressor_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = supressor.Supressor_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_spc[imagecheck].seeklength);
                        }
						//Supressor没有ilm,cav地图
/*
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = supressor.Supressor_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_ilm[imagecheck].seeklength);
                        }
*/
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = supressor.Supressor_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_ao[imagecheck].seeklength);
                        }
/*
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = supressor.Supressor_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(supressor.Supressor_cav[imagecheck].seeklength);
                        }
*/
                        break;
                    case "ThreatScope":
                        Default.Attachment.ThreatScope threatscope = new Default.Attachment.ThreatScope();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscope.ThreatScope_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscope.ThreatScope_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscope.ThreatScope_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscope.ThreatScope_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscope.ThreatScope_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscope.ThreatScope_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscope.ThreatScope_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscope.ThreatScope_cav[imagecheck].seeklength);
                        }
                        break;
                    case "ThreatScopeSniper":
                        Default.Attachment.ThreatScopeSniper threatscopesniper = new Default.Attachment.ThreatScopeSniper();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscopesniper.ThreatScopeSniper_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscopesniper.ThreatScopeSniper_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscopesniper.ThreatScopeSniper_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscopesniper.ThreatScopeSniper_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_spc[imagecheck].seeklength);
                        }
                        //ThreatScopeSniper没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscopesniper.ThreatScopeSniper_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = threatscopesniper.ThreatScopeSniper_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(threatscopesniper.ThreatScopeSniper_cav[imagecheck].seeklength);
                        }
                        break;
                    //手枪类结束

                    //轻机枪
                    case "Devotion":
                        Default.LightMachineGun.Devotion devotion = new Default.LightMachineGun.Devotion();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = devotion.Devotion_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = devotion.Devotion_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = devotion.Devotion_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = devotion.Devotion_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = devotion.Devotion_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = devotion.Devotion_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(devotion.Devotion_ao[imagecheck].seeklength);
                        }
                        //专注没有cav
                        break;
                    case "LSTAR":
                        Default.LightMachineGun.LSTAR lstar = new Default.LightMachineGun.LSTAR();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = lstar.LSTAR_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = lstar.LSTAR_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = lstar.LSTAR_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = lstar.LSTAR_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = lstar.LSTAR_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = lstar.LSTAR_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = lstar.LSTAR_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(lstar.LSTAR_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Spitfire":
                        Default.LightMachineGun.Spitfire spitfire = new Default.LightMachineGun.Spitfire();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = spitfire.Spitfire_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = spitfire.Spitfire_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = spitfire.Spitfire_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = spitfire.Spitfire_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = spitfire.Spitfire_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = spitfire.Spitfire_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = spitfire.Spitfire_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(spitfire.Spitfire_cav[imagecheck].seeklength);
                        }
                        break;

                    //榴弹枪
                    case "ColdWar":
                        Default.Grenadier.ColdWar coldwar = new Default.Grenadier.ColdWar();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = coldwar.ColdWar_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = coldwar.ColdWar_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = coldwar.ColdWar_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = coldwar.ColdWar_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = coldwar.ColdWar_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = coldwar.ColdWar_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = coldwar.ColdWar_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(coldwar.ColdWar_cav[imagecheck].seeklength);
                        }
                        break;
                    case "EPG":
                        Default.Grenadier.EPG epg = new Default.Grenadier.EPG();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = epg.EPG_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = epg.EPG_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = epg.EPG_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = epg.EPG_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = epg.EPG_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = epg.EPG_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = epg.EPG_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(epg.EPG_cav[imagecheck].seeklength);
                        }
                        break;
                    case "SMR":
                        Default.Grenadier.SMR smr = new Default.Grenadier.SMR();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = smr.SMR_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = smr.SMR_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = smr.SMR_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = smr.SMR_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_spc[imagecheck].seeklength);
                        }
                        //SMR没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = smr.SMR_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = smr.SMR_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(smr.SMR_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Softball":
                        Default.Grenadier.Softball softball = new Default.Grenadier.Softball();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = softball.Softball_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = softball.Softball_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = softball.Softball_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = softball.Softball_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_spc[imagecheck].seeklength);
                        }
                        //垒球没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = softball.Softball_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = softball.Softball_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(softball.Softball_cav[imagecheck].seeklength);
                        }
                        break;

                    //突击步枪
                    case "G2A5":
                        Default.AssaultRifle.G2A5 g2a5 = new Default.AssaultRifle.G2A5();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = g2a5.G2A5_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = g2a5.G2A5_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = g2a5.G2A5_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = g2a5.G2A5_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = g2a5.G2A5_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = g2a5.G2A5_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = g2a5.G2A5_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(g2a5.G2A5_cav[imagecheck].seeklength);
                        }
                        break;
                    case "HemlokBFR":
                        Default.AssaultRifle.HemlokBFR hemlokbfr = new Default.AssaultRifle.HemlokBFR();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = hemlokbfr.HemlokBFR_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = hemlokbfr.HemlokBFR_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = hemlokbfr.HemlokBFR_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = hemlokbfr.HemlokBFR_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = hemlokbfr.HemlokBFR_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = hemlokbfr.HemlokBFR_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = hemlokbfr.HemlokBFR_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(hemlokbfr.HemlokBFR_cav[imagecheck].seeklength);
                        }
                        break;
                    case "R101":
                        Default.AssaultRifle.R101 r101 = new Default.AssaultRifle.R101();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = r101.R101_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = r101.R101_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = r101.R101_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = r101.R101_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = r101.R101_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = r101.R101_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = r101.R101_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r101.R101_cav[imagecheck].seeklength);
                        }
                        break;
                    case "R201":
                        Default.AssaultRifle.R201 r201 = new Default.AssaultRifle.R201();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = r201.R201_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = r201.R201_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = r201.R201_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = r201.R201_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = r201.R201_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = r201.R201_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = r201.R201_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(r201.R201_cav[imagecheck].seeklength);
                        }
                        break;
                    case "V47Flatline":
                        Default.AssaultRifle.V47Flatline v47flatline = new Default.AssaultRifle.V47Flatline();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = v47flatline.V47Flatline_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = v47flatline.V47Flatline_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = v47flatline.V47Flatline_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = v47flatline.V47Flatline_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = v47flatline.V47Flatline_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = v47flatline.V47Flatline_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = v47flatline.V47Flatline_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(v47flatline.V47Flatline_cav[imagecheck].seeklength);
                        }
                        break;

                    //反泰坦武器
                    case "Archer":
                        Default.AntiTitan.Archer archer = new Default.AntiTitan.Archer();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = archer.Archer_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = archer.Archer_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = archer.Archer_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = archer.Archer_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = archer.Archer_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = archer.Archer_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = archer.Archer_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(archer.Archer_cav[imagecheck].seeklength);
                        }
                        break;
                    case "ChargeRifle":
                        Default.AntiTitan.ChargeRifle chargerifle = new Default.AntiTitan.ChargeRifle();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = chargerifle.ChargeRifle_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = chargerifle.ChargeRifle_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = chargerifle.ChargeRifle_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = chargerifle.ChargeRifle_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = chargerifle.ChargeRifle_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = chargerifle.ChargeRifle_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = chargerifle.ChargeRifle_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(chargerifle.ChargeRifle_cav[imagecheck].seeklength);
                        }
                        break;
                    case "MGL":
                        Default.AntiTitan.MGL mgl = new Default.AntiTitan.MGL();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = mgl.MGL_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = mgl.MGL_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = mgl.MGL_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = mgl.MGL_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_spc[imagecheck].seeklength);
                        }
                        //磁能榴弹没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = mgl.MGL_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = mgl.MGL_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(mgl.MGL_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Thunderbolt":
                        Default.AntiTitan.Thunderbolt thunderbolt = new Default.AntiTitan.Thunderbolt();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = thunderbolt.Thunderbolt_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = thunderbolt.Thunderbolt_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = thunderbolt.Thunderbolt_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = thunderbolt.Thunderbolt_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = thunderbolt.Thunderbolt_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = thunderbolt.Thunderbolt_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = thunderbolt.Thunderbolt_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thunderbolt.Thunderbolt_cav[imagecheck].seeklength);
                        }
                        break;
                        //泰坦武器
                    case "BroadSword":
                        Default.Titan.BroadSword broadsword = new Default.Titan.BroadSword();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = broadsword.BroadSword_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = broadsword.BroadSword_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = broadsword.BroadSword_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = broadsword.BroadSword_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_spc[imagecheck].seeklength);
                        }
                        //浪人大剑没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = broadsword.BroadSword_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = broadsword.BroadSword_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(broadsword.BroadSword_cav[imagecheck].seeklength);
                        }
                        break;
                        //no ilm,ao,cav
                    case "PrimeSword":
                        Default.Titan.PrimeSword primesword = new Default.Titan.PrimeSword();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = primesword.PrimeSword_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primesword.PrimeSword_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primesword.PrimeSword_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primesword.PrimeSword_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = primesword.PrimeSword_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primesword.PrimeSword_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primesword.PrimeSword_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primesword.PrimeSword_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = primesword.PrimeSword_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primesword.PrimeSword_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primesword.PrimeSword_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primesword.PrimeSword_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = primesword.PrimeSword_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primesword.PrimeSword_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primesword.PrimeSword_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primesword.PrimeSword_spc[imagecheck].seeklength);
                        }
                        break;
                        //Titan Skins泰坦皮肤
                        //ION 在 col,spc 中有 BC7U
                    case "ION":
                        Default.AntiTitan.ION ion = new Default.AntiTitan.ION();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = ion.ION_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = ion.ION_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = ion.ION_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = ion.ION_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = ion.ION_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = ion.ION_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = ion.ION_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ion.ION_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Legion":
                        Default.AntiTitan.Legion legion = new Default.AntiTitan.Legion();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = legion.Legion_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = legion.Legion_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = legion.Legion_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = legion.Legion_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = legion.Legion_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = legion.Legion_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = legion.Legion_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(legion.Legion_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Scorch":
                        Default.AntiTitan.Scorch scorch = new Default.AntiTitan.Scorch();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = scorch.Scorch_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = scorch.Scorch_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = scorch.Scorch_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = scorch.Scorch_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = scorch.Scorch_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = scorch.Scorch_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = scorch.Scorch_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(scorch.Scorch_cav[imagecheck].seeklength);
                        }
                        break;
                        //Northstar 在 col,spc,ilm,ao,cav 中有 BC7U
                    case "Northstar":
                        Default.AntiTitan.Northstar northstar = new Default.AntiTitan.Northstar();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = northstar.Northstar_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = northstar.Northstar_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = northstar.Northstar_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = northstar.Northstar_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = northstar.Northstar_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = northstar.Northstar_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = northstar.Northstar_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(northstar.Northstar_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Ronin":
                        Default.AntiTitan.Ronin ronin = new Default.AntiTitan.Ronin();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = ronin.Ronin_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = ronin.Ronin_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = ronin.Ronin_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = ronin.Ronin_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = ronin.Ronin_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = ronin.Ronin_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = ronin.Ronin_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(ronin.Ronin_cav[imagecheck].seeklength);
                        }
                        break;
                    case "Tone":
                        Default.AntiTitan.Tone tone = new Default.AntiTitan.Tone();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = tone.Tone_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = tone.Tone_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = tone.Tone_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = tone.Tone_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = tone.Tone_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = tone.Tone_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = tone.Tone_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(tone.Tone_cav[imagecheck].seeklength);
                        }
                        break;
                        //Cant find find HeX code for normal, ilm and cav map because it blank images
                    case "Monarch":
                        Default.AntiTitan.Monarch monarch = new Default.AntiTitan.Monarch();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = monarch.Monarch_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_col[imagecheck].seeklength);
                        }
                        /*
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = monarch.Monarch_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_nml[imagecheck].seeklength);
                        }
                        */
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = monarch.Monarch_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = monarch.Monarch_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_spc[imagecheck].seeklength);
                        }
                        /*
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = monarch.Monarch_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_ilm[imagecheck].seeklength);
                        }
                        */
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = monarch.Monarch_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_ao[imagecheck].seeklength);
                        }
                        /*
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = monarch.Monarch_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(monarch.Monarch_cav[imagecheck].seeklength);
                        }
                        */
                        break;
                    case "PrimeLegion":
                        Default.AntiTitan.PrimeLegion primelegion = new Default.AntiTitan.PrimeLegion();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = primelegion.PrimeLegion_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = primelegion.PrimeLegion_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = primelegion.PrimeLegion_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = primelegion.PrimeLegion_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = primelegion.PrimeLegion_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = primelegion.PrimeLegion_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = primelegion.PrimeLegion_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primelegion.PrimeLegion_cav[imagecheck].seeklength);
                        }
                        break;
                    case "PrimeNorthstar":
                        Default.AntiTitan.PrimeNorthstar primenorthstar = new Default.AntiTitan.PrimeNorthstar();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = primenorthstar.PrimeNorthstar_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = primenorthstar.PrimeNorthstar_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = primenorthstar.PrimeNorthstar_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = primenorthstar.PrimeNorthstar_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = primenorthstar.PrimeNorthstar_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = primenorthstar.PrimeNorthstar_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = primenorthstar.PrimeNorthstar_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primenorthstar.PrimeNorthstar_cav[imagecheck].seeklength);
                        }
                        break;
                    case "PrimeION":
                        Default.AntiTitan.PrimeION primeion = new Default.AntiTitan.PrimeION();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeion.PrimeION_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeion.PrimeION_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeion.PrimeION_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeion.PrimeION_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeion.PrimeION_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeion.PrimeION_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeion.PrimeION_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeion.PrimeION_cav[imagecheck].seeklength);
                        }
                        break;
                    case "PrimeRonin":
                        Default.AntiTitan.PrimeRonin primeronin = new Default.AntiTitan.PrimeRonin();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeronin.PrimeRonin_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeronin.PrimeRonin_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeronin.PrimeRonin_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeronin.PrimeRonin_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeronin.PrimeRonin_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeronin.PrimeRonin_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = primeronin.PrimeRonin_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primeronin.PrimeRonin_cav[imagecheck].seeklength);
                        }
                        break;
                    case "PrimeScorch":
                        Default.AntiTitan.PrimeScorch primescorch = new Default.AntiTitan.PrimeScorch();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = primescorch.PrimeScorch_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = primescorch.PrimeScorch_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = primescorch.PrimeScorch_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = primescorch.PrimeScorch_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = primescorch.PrimeScorch_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = primescorch.PrimeScorch_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = primescorch.PrimeScorch_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primescorch.PrimeScorch_cav[imagecheck].seeklength);
                        }
                        break;
                    case "PrimeTone":
                        Default.AntiTitan.PrimeTone primetone = new Default.AntiTitan.PrimeTone();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = primetone.PrimeTone_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = primetone.PrimeTone_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = primetone.PrimeTone_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = primetone.PrimeTone_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = primetone.PrimeTone_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = primetone.PrimeTone_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = primetone.PrimeTone_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(primetone.PrimeTone_cav[imagecheck].seeklength);
                        }
                        break;
                    case "JackHandL":
                        Default.JackParts.JackHandL jackhandl = new Default.JackParts.JackHandL();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = jackhandl.JackHandL_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = jackhandl.JackHandL_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = jackhandl.JackHandL_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = jackhandl.JackHandL_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = jackhandl.JackHandL_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = jackhandl.JackHandL_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = jackhandl.JackHandL_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandl.JackHandL_cav[imagecheck].seeklength);
                        }
                        break;
                    case "JackHandR":
                        Default.JackParts.JackHandR jackhandr = new Default.JackParts.JackHandR();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = jackhandr.JackHandR_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandr.JackHandR_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandr.JackHandR_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(jackhandr.JackHandR_col[imagecheck].seeklength);
                        }
                        break;
                    case "LeadWall":
                        Default.Titan.LeadWall leadwall = new Default.Titan.LeadWall();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = leadwall.LeadWall_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = leadwall.LeadWall_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = leadwall.LeadWall_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = leadwall.LeadWall_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_spc[imagecheck].seeklength);
                        }
                        //天女散花没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = leadwall.LeadWall_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = leadwall.LeadWall_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(leadwall.LeadWall_cav[imagecheck].seeklength);
                        }
                        break;
                    case "PlasmaRailgun":
                        Default.Titan.PlasmaRailgun plasmarailgun = new Default.Titan.PlasmaRailgun();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = plasmarailgun.PlasmaRailgun_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = plasmarailgun.PlasmaRailgun_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = plasmarailgun.PlasmaRailgun_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = plasmarailgun.PlasmaRailgun_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = plasmarailgun.PlasmaRailgun_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = plasmarailgun.PlasmaRailgun_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = plasmarailgun.PlasmaRailgun_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(plasmarailgun.PlasmaRailgun_cav[imagecheck].seeklength);
                        }
                        break;
                    case "PredatorCannon":
                        Default.Titan.PredatorCannon predatorcannon = new Default.Titan.PredatorCannon();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = predatorcannon.PredatorCannon_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = predatorcannon.PredatorCannon_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = predatorcannon.PredatorCannon_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = predatorcannon.PredatorCannon_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_spc[imagecheck].seeklength);
                        }
                        //猎杀者机炮没有ilm和cav
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = predatorcannon.PredatorCannon_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(predatorcannon.PredatorCannon_ao[imagecheck].seeklength);
                        }
                        break;
                    case "SplitterRifle":
                        Default.Titan.SplitterRifle splitterrifle = new Default.Titan.SplitterRifle();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = splitterrifle.SplitterRifle_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = splitterrifle.SplitterRifle_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = splitterrifle.SplitterRifle_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = splitterrifle.SplitterRifle_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_spc[imagecheck].seeklength);
                        }
                        //分裂枪没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = splitterrifle.SplitterRifle_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = splitterrifle.SplitterRifle_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(splitterrifle.SplitterRifle_cav[imagecheck].seeklength);
                        }
                        break;
                    case "ThermiteLauncher":
                        Default.Titan.ThermiteLauncher thermitelauncher = new Default.Titan.ThermiteLauncher();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = thermitelauncher.ThermiteLauncher_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = thermitelauncher.ThermiteLauncher_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = thermitelauncher.ThermiteLauncher_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = thermitelauncher.ThermiteLauncher_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_spc[imagecheck].seeklength);
                        }
                        //T203铝热剂发射器没有ilm
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = thermitelauncher.ThermiteLauncher_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = thermitelauncher.ThermiteLauncher_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(thermitelauncher.ThermiteLauncher_cav[imagecheck].seeklength);
                        }
                        break;
                    case "TrackerCannon":
                        Default.Titan.TrackerCannon trackercannon = new Default.Titan.TrackerCannon();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = trackercannon.TrackerCannon_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = trackercannon.TrackerCannon_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = trackercannon.TrackerCannon_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = trackercannon.TrackerCannon_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = trackercannon.TrackerCannon_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = trackercannon.TrackerCannon_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = trackercannon.TrackerCannon_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(trackercannon.TrackerCannon_cav[imagecheck].seeklength);
                        }
                        break;
                    case "XO16":
                        Default.Titan.XO16 xo16 = new Default.Titan.XO16();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = xo16.XO16_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = xo16.XO16_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = xo16.XO16_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = xo16.XO16_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_spc[imagecheck].seeklength);
                        }
                        if (str.Contains("ilm"))
                        {
                            int i = 0;
                            FilePath[0, i] = xo16.XO16_ilm[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_ilm[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_ilm[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_ilm[imagecheck].seeklength);
                        }
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = xo16.XO16_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_ao[imagecheck].seeklength);
                        }
                        if (str.Contains("cav"))
                        {
                            int i = 0;
                            FilePath[0, i] = xo16.XO16_cav[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_cav[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_cav[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(xo16.XO16_cav[imagecheck].seeklength);
                        }
                        break;
                    //近战武器
                    case "Sword":
                        Default.Melee.Sword sword = new Default.Melee.Sword();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = sword.Sword_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = sword.Sword_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = sword.Sword_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = sword.Sword_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_spc[imagecheck].seeklength);
                        }
                        //铁驭剑没有ilm贴图
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = sword.Sword_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(sword.Sword_ao[imagecheck].seeklength);
                        }
                        //铁驭剑没有cav贴图
                        break;
                    case "Kunai":
                        Default.Melee.Kunai kunai = new Default.Melee.Kunai();
                        if (str.Contains("col"))
                        {
                            int i = 0;
                            FilePath[0, i] = kunai.Kunai_col[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_col[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_col[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_col[imagecheck].seeklength);
                        }
                        if (str.Contains("nml"))
                        {
                            int i = 0;
                            FilePath[0, i] = kunai.Kunai_nml[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_nml[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_nml[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_nml[imagecheck].seeklength);
                        }
                        if (str.Contains("gls"))
                        {
                            int i = 0;
                            FilePath[0, i] = kunai.Kunai_gls[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_gls[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_gls[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_gls[imagecheck].seeklength);
                        }
                        if (str.Contains("spc"))
                        {
                            int i = 0;
                            FilePath[0, i] = kunai.Kunai_spc[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_spc[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_spc[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_spc[imagecheck].seeklength);
                        }
                        //苦无没有ilm贴图
                        if (str.Contains("ao"))
                        {
                            int i = 0;
                            FilePath[0, i] = kunai.Kunai_ao[imagecheck].name;
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_ao[imagecheck].seek);
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_ao[imagecheck].length);
                            i++;
                            FilePath[0, i] = Convert.ToString(kunai.Kunai_ao[imagecheck].seeklength);
                        }
                        //苦无没有cav贴图
                        break;
                    default:
                      Console.WriteLine("The File - " + WeaponName + "Was not valid");
                        break;
                }
            }
            else if (WeaponName.Contains("Skin31"))
            {//TODO as of 2022-06-10
               //Custom Skin Slots here.
            }
        }
    }
}
