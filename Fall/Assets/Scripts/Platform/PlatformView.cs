/* --------------------------------------------------------------------------
    Title       :  PlatformView
    Date        :  22:53:20
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
    public class PlatformView : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer renderer = null;

        [SerializeField]
        private Collider collider = null;
        
        [Inject]
        public PlatformFacade Facade
        {
            get; set;
        }
        
        public MeshRenderer Renderer
        {
            get { return renderer; }
        }

        public Collider Collider
        {
            get { return collider; }
        }
        
        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public Quaternion Rotation
        {
            get { return transform.rotation; }
            set { transform.rotation = value; }
        }

        public void MoveUp(float amount)
        {
            Vector2 temp = transform.position;
            temp.y += amount;
            Position = temp;
        }
    }
}