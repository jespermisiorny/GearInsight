using GearInsight.Models;
using GearInsight.Services;
using GearInsight.ViewModels;

namespace GearInsight.Views;

public partial class CharacterPage : ContentPage
{
    CharacterPageViewModel viewModel = new CharacterPageViewModel();

    public CharacterPage()
	{
		InitializeComponent();
        BindingContext = viewModel;
    }

    private async void GoBackToMainPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Task test = viewModel.SetItems();
        await test;
        if (App.UltimateCharacter.PlayedClass == "Warrior" || App.UltimateCharacter.PlayedClass == "Death Knight" || App.UltimateCharacter.ActiveSpec == "Retribution" || App.UltimateCharacter.ActiveSpec == "Protection" )
        {
            VersStat.Text = App.UltimateCharacter.VersatilityPercent + "%";
            MasteryStat.Text = Math.Round((double)App.UltimateCharacter.Mastery.Percent) + "%";
            CritStat.Text = Math.Round((double)App.UltimateCharacter.MeleeCrit.Percent).ToString() + "%";
            HasteStat.Text = Math.Round((double)App.UltimateCharacter.MeleeHaste.Percent).ToString() + "%";
            BaseStat.Text = App.UltimateCharacter.Strength.Rating.ToString();
            BaseLabel.Text = "Strength";
            BaseStatImg.Source = "strength.png";
            RoleImg.Source = "role_dmg.png";
            if (App.UltimateCharacter.PlayedClass == "Warrior")
            {
                PowerImg.Source = "rage.png";
                PowerLabel.Text = "Rage";
                if (App.UltimateCharacter.ActiveSpec == "Protection")
                {
                    RoleImg.Source = "role_tank.png";
                }
            }
            else if (App.UltimateCharacter.PlayedClass == "Death Knight")
            {
                PowerImg.Source = "runicpower.png";
                PowerLabel.Text = "Runic Power";
                if (App.UltimateCharacter.ActiveSpec == "Blood")
                {
                    RoleImg.Source = "role_tank.png";
                }
            }
            else
            {
                PowerImg.Source = "mana.png";
                PowerLabel.Text = "Mana";
            }
            
        }
        else if (App.UltimateCharacter.PlayedClass == "Rogue" || App.UltimateCharacter.PlayedClass == "Demon Hunter" || App.UltimateCharacter.ActiveSpec == "Survival" || App.UltimateCharacter.ActiveSpec == "Windwalker" || App.UltimateCharacter.ActiveSpec == "Brewmaster" || App.UltimateCharacter.ActiveSpec == "Feral" || App.UltimateCharacter.ActiveSpec == "Enhancement" || App.UltimateCharacter.ActiveSpec == "Guardian")
        {
            VersStat.Text = App.UltimateCharacter.VersatilityPercent + "%";
            MasteryStat.Text = Math.Round((double)App.UltimateCharacter.Mastery.Percent) + "%";
            CritStat.Text = Math.Round((double)App.UltimateCharacter.MeleeCrit.Percent).ToString() + "%";
            HasteStat.Text = Math.Round((double)App.UltimateCharacter.MeleeHaste.Percent).ToString() + "%";
            BaseStat.Text = App.UltimateCharacter.Agility.Rating.ToString();
            BaseLabel.Text = "Agility";
            BaseStatImg.Source = "agility.png";
            RoleImg.Source = "role_dmg.png";
            if (App.UltimateCharacter.PlayedClass == "Rogue" || App.UltimateCharacter.ActiveSpec == "Windwalker" || App.UltimateCharacter.ActiveSpec == "Brewmaster" || App.UltimateCharacter.ActiveSpec == "Feral")
            {
                PowerImg.Source = "energy.png";
                PowerLabel.Text = "Energy";
                if (App.UltimateCharacter.ActiveSpec == "Brewmaster")
                {
                    RoleImg.Source = "role_tank.png";
                }
            }
            else if (App.UltimateCharacter.PlayedClass == "Demon Hunter")
            {
                PowerImg.Source = "fury.png";
                PowerLabel.Text = "Fury";
                if (App.UltimateCharacter.ActiveSpec == "Vengeance")
                {
                    RoleImg.Source = "role_tank.png";
                    PowerLabel.Text = "Pain";
                }
            }
            else if (App.UltimateCharacter.ActiveSpec == "Survival")
            {
                PowerImg.Source = "focus.png";
                PowerLabel.Text = "Focus";

            }
            else if (App.UltimateCharacter.ActiveSpec == "Enhancement" || App.UltimateCharacter.ActiveSpec == "Guardian")
            {
                PowerImg.Source = "mana.png";
                PowerLabel.Text = "Mana";
                if (App.UltimateCharacter.ActiveSpec == "Guardian")
                {
                    RoleImg.Source = "role_tank.png";
                }
            }
        }
        else if (App.UltimateCharacter.PlayedClass == "Hunter")
        {
            VersStat.Text = App.UltimateCharacter.VersatilityPercent + "%";
            MasteryStat.Text = Math.Round((double)App.UltimateCharacter.Mastery.Percent) + "%";
            CritStat.Text = Math.Round((double)App.UltimateCharacter.RangeCrit.Percent).ToString() + "%";
            HasteStat.Text = Math.Round((double)App.UltimateCharacter.RangeHaste.Percent).ToString() + "%";
            BaseStat.Text = App.UltimateCharacter.Agility.Rating.ToString();
            BaseLabel.Text = "Agility";
            BaseStatImg.Source = "agility.png";
            PowerImg.Source = "focus.png";
            PowerLabel.Text = "Focus";
            RoleImg.Source = "role_dmg.png";
        }
        else
        {
            VersStat.Text = App.UltimateCharacter.VersatilityPercent + "%";
            MasteryStat.Text = Math.Round((double)App.UltimateCharacter.Mastery.Percent) + "%";
            CritStat.Text = Math.Round((double)App.UltimateCharacter.SpellCrit.Percent).ToString() + "%";
            HasteStat.Text = Math.Round((double)App.UltimateCharacter.SpellHaste.Percent).ToString() + "%";
            BaseStat.Text = App.UltimateCharacter.Intellect.Rating.ToString();
            BaseLabel.Text = "Intellect";
            BaseStatImg.Source = "intellect.png";
            PowerImg.Source = "mana.png";
            PowerLabel.Text = "Mana";
            RoleImg.Source = "role_dmg.png";

            if (App.UltimateCharacter.ActiveSpec == "Holy" || App.UltimateCharacter.ActiveSpec == "Restoration" || App.UltimateCharacter.ActiveSpec == "Discipline" || App.UltimateCharacter.ActiveSpec == "Preservation" || App.UltimateCharacter.ActiveSpec == "Mistweaver")
            {
                RoleImg.Source = "role_healer.png";
            }

        }
        //HeadLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Head.Quality);
        //HeadFrame.BorderColor = HeadLabel.TextColor;
        //NeckLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Neck.Quality);
        //NeckFrame.BorderColor = NeckLabel.TextColor;
        //ShoulderLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Shoulder.Quality);
        //ShoulderFrame.BorderColor = ShoulderLabel.TextColor;
        //ChestLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Chest.Quality);
        //ChestFrame.BorderColor = ChestLabel.TextColor;
        //BackLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Back.Quality);
        //BackFrame.BorderColor = BackLabel.TextColor;
        //TabardLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Tabard.Quality);
        //TabardFrame.BorderColor = TabardLabel.TextColor;
        //ShirtLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Shirt.Quality);
        //ShirtFrame.BorderColor = ShirtLabel.TextColor;
        //WristLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Wrist.Quality);
        //WristFrame.BorderColor = WristLabel.TextColor;
        //HandsLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Hands.Quality);
        //HandsFrame.BorderColor = HandsLabel.TextColor;
        //WaistLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Waist.Quality);
        //WaistFrame.BorderColor = WaistLabel.TextColor;
        //LegsLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Legs.Quality);
        //LegsFrame.BorderColor = LegsLabel.TextColor;
        //FeetLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Feet.Quality);
        //FeetFrame.BorderColor = FeetLabel.TextColor;
        //Ring1Label.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Ring1.Quality);
        //Ring1Frame.BorderColor = Ring1Label.TextColor;
        //Ring2Label.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Ring2.Quality);
        //Ring2Frame.BorderColor = Ring2Label.TextColor;
        //Trinket1Label.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Trinket1.Quality);
        //Trinket1Frame.BorderColor = Trinket1Label.TextColor;
        //Trinket2Label.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Trinket2.Quality);
        //Trinket2Frame.BorderColor = Trinket2Label.TextColor;
        //MainhandLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Mainhand.Quality);
        //MainhandFrame.BorderColor = MainhandLabel.TextColor;
        //OffhandLabel.TextColor = SetTextColor.SetColor(App.UltimateCharacter.Offhand.Quality);
        //OffhandFrame.BorderColor = OffhandLabel.TextColor;

        //HeadLabel.Text = Helpers.CheckItemIsNull(App.UltimateCharacter.Head);
        //HeadLabel.Text = Helpers.CheckItemIsNull(App.UltimateCharacter.Head);
        //HeadLabel.Text = Helpers.CheckItemIsNull(App.UltimateCharacter.Head);
        //HeadLabel.Text = Helpers.CheckItemIsNull(App.UltimateCharacter.Head);
        //HeadLabel.Text = Helpers.CheckItemIsNull(App.UltimateCharacter.Head);
       
        
        


    }

    private async void RefreshCharacterPage_Clicked(object sender, EventArgs e)
    {
        Task refresh = Mongo.RefreshData(App.UltimateCharacter.CharacterName.ToLower(), App.UltimateCharacter.Realm.ToLower());
        await refresh;
        await Navigation.PopAsync();
    }
}