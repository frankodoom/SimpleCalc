using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using BusinessLogic;
using BusinessLogic.Service.Interfaces;

namespace SimpleCalc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
     
        private EditText editNum1, editNum2;
        private decimal num1, num2;
        private decimal output;
        private Button btnCompute;
        private Spinner operation;
        private  string selectedOperation;
        AlertDialog.Builder alert;
        private IMathService mathService;
  

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //initialize DI Contianer
            Container.Initialize();
            mathService = Container.mathService;

            btnCompute = FindViewById<Button>(Resource.Id.btnCompute);
            operation = FindViewById<Spinner>(Resource.Id.spinner_operator);
            editNum1 = FindViewById<EditText>(Resource.Id.edit_num1);
            editNum2 = FindViewById<EditText>(Resource.Id.edit_num2);
            alert = new AlertDialog.Builder(this);

            btnCompute.Click += BtnCompute_Click;
            operation.ItemSelected += Operation_ItemSelected;
        }

        private void Operation_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            selectedOperation = operation.GetItemAtPosition(e.Position).ToString();
            //Toast.MakeText(this, selectedOperation, ToastLength.Long).Show();
        }

        private void BtnCompute_Click(object sender, System.EventArgs e)
        {
            num1 = decimal.Parse(editNum1.Text);
            num2 = decimal.Parse(editNum2.Text);

            alert.SetTitle("Answer");

            if (num1.Equals(null))
            {
                editNum1.SetError("Num1 Cannot be Empty",null);
            }

            if (num2.Equals(null))
            {
                editNum1.SetError("Num2 Cannot be Empty", null);
            }


            switch (selectedOperation)
            {
                case "Add":        
                    output = mathService.Add(num1,num2);
                    //Display Alert                          
                    alert.SetMessage("The sum is "+ output);
                    alert.Show();
                    break;

                case "Subtract":
                   output = mathService.Subtract(num1,num2);
                    //Display Alert                          
                    alert.SetMessage("The difference is " + output);
                    alert.Show();
                    break;

                case "Multiply":
                    output = mathService.Multiply(num1, num2);
                    //Display Alert                          
                    alert.SetMessage("The product is " + output);
                    alert.Show();
                    break;

                case "Divide":
                    output = mathService.Divide(num1, num2);
                    //Display Alert                          
                    alert.SetMessage("The quotient is " + output);
                    alert.Show();
                    break;
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

         bool isNull(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            return true;
        }
    }
}