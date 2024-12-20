/* --------------------------------------------------------------------------
    Title       :  GameSettingsInstaller
    Date        :  2 Kasım 2024
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
using Zenject.SpaceFighter;

namespace Persephone.Installers
{
    [CreateAssetMenu(fileName = "Fall", menuName = "Fall/GameInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public GameInstaller.Settings GameInstaller;
        public PlatformSpawner.Settings PlatformSpawner;
        public PlatformSettings Platform;

        [Serializable]
        public class PlatformSettings
        {
            public PlatformMovementHandler.Settings PlatformMovement;
        }
        
        public override void InstallBindings()
        {
            Container.BindInstance(PlatformSpawner).IfNotBound();
            Container.BindInstance(GameInstaller).IfNotBound();
            Container.BindInstance(Platform.PlatformMovement).IfNotBound();
        }
    }
}