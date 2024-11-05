/* --------------------------------------------------------------------------
    Title       :  PlatformFacade
    Date        :  22:51:12
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

namespace Persephone
{
    public class PlatformFacade : MonoBehaviour, IPoolable<float, IMemoryPool>, IDisposable
    {
        private PlatformView view;
        private PlatformRegistry registry;
        private IMemoryPool pool;
        
        [Inject]
        public void Construct(PlatformView view, PlatformRegistry registry)
        {
            this.view = view;
            this.registry = registry;
        }
        
        public void Dispose()
        {
            pool.Despawn(this);
        }
        
        public Vector3 Position
        {
            get { return view.Position; }
            set { view.Position = value; }
        }
        
        public void OnDespawned()
        {
            registry.RemoveEnemy(this);
            pool = null;
        }

        public void OnSpawned(float t, IMemoryPool pool)
        {
            this.pool = pool;
            registry.AddEnemy(this);
        }
        
        public class Factory : PlaceholderFactory<float, PlatformFacade>
        {
        }
    }
}