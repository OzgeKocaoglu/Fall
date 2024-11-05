/* --------------------------------------------------------------------------
    Title       :  GameInstaller
    Date        :  2 Kasım 2024 Cumartesi
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

namespace Persephone.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [Inject]
        Settings settings = null;
        
        public override void InstallBindings() 
        {
            Container.BindInterfacesAndSelfTo<PlatformSpawner>().AsSingle();
            
            Container.BindFactory<float, PlatformFacade, PlatformFacade.Factory>()
                .FromPoolableMemoryPool<float, PlatformFacade, PlatformFacadePool>(poolBinder => poolBinder
                    .WithInitialSize(5)
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<PlatformInstaller>(settings.PlatformPrefab)
                    .UnderTransformGroup("Platforms"));
            
            Container.BindFactory<float, SpikePlatformFacade, SpikePlatformFacade.Factory>()
                .FromPoolableMemoryPool<float, SpikePlatformFacade, SpikePlatformFacadePool>(poolBinder => poolBinder
                    .WithInitialSize(5)
                    .FromSubContainerResolve()
                    .ByNewPrefabInstaller<PlatformInstaller>(settings.SpikePlatformPrefab)
                    .UnderTransformGroup("SpikePlatforms"));
            
            Container.Bind<LevelBoundary>().AsSingle();
            
            Container.Bind<PlatformRegistry>().AsSingle();

            GameSignalsInstaller.Install(Container);

        }
        
        [Serializable]
        public class Settings
        {
            public GameObject PlatformPrefab;
            public GameObject SpikePlatformPrefab;
        }
        
        class PlatformFacadePool : MonoPoolableMemoryPool<float, IMemoryPool, PlatformFacade>
        {
        }
        
        class SpikePlatformFacadePool : MonoPoolableMemoryPool<float, IMemoryPool, SpikePlatformFacade>
        {
        }
    }
}