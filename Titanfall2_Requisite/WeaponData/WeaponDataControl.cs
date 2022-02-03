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
        public string[,] FilePath = new string[1, 4];
        //col，nml，gls，spc，ilm，ao，cav
        //2为2048x2048,1为1024x1024,0为512x512
        public WeaponDataControl(string WeaponName, int imagecheck)
        {
            //单独为专注的弹夹写判断emmm。。。。
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
            if (WeaponName.Contains("Devotion_clip") && WeaponName.Contains("Skin31"))
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
            string s = WeaponName;
            int toname = s.LastIndexOf("\\")+1;
            string str = s.Substring(toname, s.Length - toname);
            toname = str.IndexOf("_");
            string temp = str.Substring(toname, str.Length - toname);
            s = str.Replace(temp, "");
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
                    default:
                        break;
                }
            }
            else if (WeaponName.Contains("Skin31"))
            {
                //等待RPAK文件开发中...
                //To do...
            }
        }
    }
}
