﻿using System;
using UIKit;

namespace ReadyToUseUIDemo.iOS.Service
{
    public class ImagePicker
    {
        public static readonly ImagePicker Instance = new ImagePicker();

        UIImagePickerController controller;
        public UIImagePickerController Controller
        {
            get
            {
                if (controller == null)
                {
                    controller = new UIImagePickerController
                    {
                        SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                        MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
                    };
                }

                return controller;
            }
        }

        public void Present(UIViewController controller)
        {
            controller.PresentViewController(Controller, true, null);
            Controller.Canceled += Cancelled;
        }

        private void Cancelled(object sender, EventArgs e)
        {
            Dismiss();
        }

        public void Dismiss()
        {
            Controller.DismissModalViewController(false);
            Controller.Canceled -= Cancelled;
        }
    }
}
