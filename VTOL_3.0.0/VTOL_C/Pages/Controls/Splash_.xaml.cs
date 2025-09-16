using System;
using System.Collections.Generic;
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
using Wpf.Ui.Controls;

using TextBlock = System.Windows.Controls.TextBlock;

namespace VTOL_C.Pages.Controls
{
    /// <summary>
    /// Interaction logic for Splash_.xaml
    /// </summary>
    /// 
    public class RandomPhraseDisplay
    {
        private readonly TextBlock textBlock;
        private readonly List<string> loadingPhrases;
        private readonly Random random;

        public RandomPhraseDisplay(TextBlock textBlock)
        {
            this.textBlock = textBlock;
            this.random = new Random();
            this.loadingPhrases = new List<string>
{
    "Loading Titan Chassis...",
    "Pilot Regen System online and copying...",
    "Downloading Simulacrum...",
    "Calibrating Jump Kit...",
    "Syncing Neural Link...",
    "Charging Arc Cannon...",
    "Initializing Smart Pistol...",
    "Deploying Ticks...",
    "Activating Cloak...",
    "Spinning up Spitfire...",
    "Patching Titanfall...",
    "Respawning Pilots...",
    "Recharging Shields...",
    "Pinging Enemy Location...",
    "Launching Northstar...",
    "Igniting Scorch's Incendiary Traps...",
    "Calculating Grapple Trajectory...",
    "Synthesizing Stim...",
    "Rerouting A-Wall...",
    "Compiling Holo Pilot Data...",
    "Engaging Phase Shift...",
    "Booting up Pulse Blade...",
    "Priming Firestar...",
    "Arming Gravity Star...",
    "Charging Laser Core...",
    "Activating Sword Core...",
    "Initializing Salvo Core...",
    "Powering up Flight Core...",
    "Priming Smart Core...",
    "Engaging Flame Core...",
    "Updating Titan OS...",
    "Optimizing Wallrun Mechanics...",
    "Reloading Mozambique...",
    "Polishing Titan Optics...",
    "Lubricating Titan Joints...",
    "Synchronizing Pilot-Titan Neural Link...",
    "Calculating Optimal Titanfall Landing Zone...",
    "Recharging Electric Smoke...",
    "Tuning Titan Dash Capacitors...",
    "Initializing Rodeo Protocols...",
    "Updating Frontier Defense Strategies...",
    "Compiling Coliseum Match Data...",
    "Optimizing Titan Eject Sequence...",
    "Calculating Kraber Bullet Drop...",
    "Refining Tone's Tracking Systems...",
    "Updating Legion's Predator Cannon...",
    "Calibrating Ronin's Sword Block...",
    "Adjusting Ion's Energy Transfer...",
    "Fine-tuning Monarch's Upgrade Core...",
    "Simulating Titan Executions...",
    "Updating Pilot Helmet HUD..."
};
        }

        public void DisplayRandomPhrase()
        {
            string randomPhrase = loadingPhrases[random.Next(loadingPhrases.Count)];
            textBlock.Text = randomPhrase;
        }
    }

    public partial class Splash_ : Window
    {
        private readonly List<string> loadingPhrases;
        private readonly Random random;
        private RandomPhraseDisplay phraseDisplay;
        public async void WaitAndDisableTopmost()
        {
            // Wait for 5 seconds
            await Task.Delay(5000);

            // Get the topmost element of the current window
            var topmostElement = VisualTreeHelper.GetChild(this, 0);

            // Disable the topmost element
            (topmostElement as FrameworkElement)?.SetValue(UIElement.IsEnabledProperty, false);
            this.Topmost = false;
        }

        public Splash_()
        {
            InitializeComponent();
            // Set the TextBlock as the content of the window
           // this.Content = Loader;

            // Initialize the RandomPhraseDisplay
            phraseDisplay = new RandomPhraseDisplay(Loader);
            phraseDisplay.DisplayRandomPhrase();
            WaitAndDisableTopmost();

        }
    }
}
