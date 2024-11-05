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
        PlatformFacade.Factory platformFactory;
        SpikePlatformFacade.Factory spikeFactory;
        readonly SignalBus signalBus;
        readonly Settings settings;
        readonly LevelBoundary levelBoundary;

        private int desiredNumPlatforms;
        private int platformCount;
        private float lastSpawnTime;
        
        public PlatformSpawner(Settings settings, LevelBoundary levelBoundary, SignalBus signalBus, PlatformFacade.Factory platformFactory, SpikePlatformFacade.Factory spikeFactory)
        {
            this.platformFactory = platformFactory;
            this.signalBus = signalBus;
            this.levelBoundary = levelBoundary;
            this.settings = settings;
            this.spikeFactory = spikeFactory;
            
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
            int randomIndex = Random.Range(0, 2);
            PlatformFacade platform = null;

            if (randomIndex == 0)
            {
                platform = platformFactory.Create(0f);
            }
            else
            {
                platform = spikeFactory.Create(0f);
            }
            
            platform.Position = ChooseRandomStartPosition();
            lastSpawnTime = Time.realtimeSinceStartup;
        }
        
        Vector3 ChooseRandomStartPosition()
        {
            var temp = Vector3.zero;
            temp.x = Random.Range(-3, 3);
            temp.y = levelBoundary.Bottom -1;

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