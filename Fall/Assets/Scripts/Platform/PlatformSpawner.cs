/* --------------------------------------------------------------------------
    Title       :  PlatformSpawner
    Date        :  22:37:37
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

using Random = UnityEngine.Random;

namespace Persephone
{
    public class PlatformSpawner : ITickable, IInitializable
    {
        PlatformFacade.Factory factory;
        readonly SignalBus signalBus;
        readonly Settings settings;
        readonly LevelBoundary levelBoundary;

        private int desiredNumPlatforms;
        private int platformCount;
        private float lastSpawnTime;
        
        public PlatformSpawner(Settings settings, LevelBoundary levelBoundary, SignalBus signalBus, PlatformFacade.Factory factory)
        {
            this.factory = factory;
            this.signalBus = signalBus;
            this.levelBoundary = levelBoundary;
            this.settings = settings;
            
            desiredNumPlatforms = (int) settings.NumPlatformsStartAmount;
        }
        
        public void Initialize()
        {
            signalBus.Subscribe<PlatformWentOutsideSignal>(OnPlatformWentOutside);
        }
        
        public void Tick()
        {
            if (platformCount < desiredNumPlatforms && Time.realtimeSinceStartup - lastSpawnTime > settings.MinDelayBetweenSpawns)
            {
                SpawnPlatform();
                platformCount++;
            }
        }
        
        void OnPlatformWentOutside()
        {
            platformCount--;
        }

        void SpawnPlatform()
        {
            var platformFacade = factory.Create(0f);
            platformFacade.Position = ChooseRandomStartPosition();
            Debug.Log(platformFacade.gameObject.name);
            
            lastSpawnTime = Time.realtimeSinceStartup;
        }
        
        Vector3 ChooseRandomStartPosition()
        {
            var temp = Vector3.zero;
            temp.x = Random.Range(-levelBoundary.Left, levelBoundary.Right);

            return temp;
            
        }
        
        [Serializable]
        public class Settings
        {
            public float NumPlatformsIncreaseRate;
            public float NumPlatformsStartAmount;
            public float MinDelayBetweenSpawns = 2f;
        }
    }
}