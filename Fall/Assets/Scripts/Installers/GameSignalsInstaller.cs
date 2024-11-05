/* --------------------------------------------------------------------------
    Title       :  GameSignalsInstaller
    Date        :  4 Kasım 2024 Pazartesi
    Programmer  :  Ozge Kocaoglu
    Package     :  Version 1.0
    Copyright   :  MIT License
-------------------------------------------------------------------------- */
/* --------------------------------------------------------------------------
    Copyright (c) 2024 Ozge Kocaoglu

 THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 SOFTWARE.
-------------------------------------------------------------------------- */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;
using Persephone.Signals;

namespace Persephone.Installers
{
    public class GameSignalsInstaller : Installer<GameSignalsInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<PlatformWentOutsideSignal>();
            Container.DeclareSignal<PlayerDiedSignal>();

            // Include these just to ensure BindSignal works
            Container.BindSignal<PlayerDiedSignal>().ToMethod<PlatformWentOutsideSignalObserver>(x => x.OnPlatformWentOut).FromNew();
            Container.BindSignal<PlatformWentOutsideSignal>().ToMethod(() => Debug.Log("Fired EnemyKilledSignal"));
        }
        
        public class PlatformWentOutsideSignalObserver
        {
            public void OnPlatformWentOut()
            {
                Debug.Log("platform Went out");
            }
        }

    }
}