import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormlyFieldConfig, FormlyFormOptions } from '@ngx-formly/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'FormlyTesting';

  form = new FormGroup({});
  model = { email: 'email@gmail.com' };
  options: FormlyFormOptions = {};
  fields: FormlyFieldConfig[] = [
    {
      key: 'email',
      type: 'input',
      templateOptions: {
        label: 'Email address',
        placeholder: 'Enter email',
        required: true,
      }
    },
    {
      key: 'first name',
      type: 'input',
      templateOptions: {
        label: 'First Name',
        placeholder: 'Enter First Name',
        required: true,
      }
    },
    {
      key: 'address',
      wrappers: ['panel'],
      templateOptions: { label: 'Address' },
      fieldGroup: [{
        key: 'Street',
        type: 'input',
        templateOptions: {
          required: true,
          type: 'text',
          label: 'Street',
        },
      },
      {
        key: 'City',
        type: 'input',
        templateOptions: {
          required: true,
          type: 'text',
          label: 'City',
        },
      },
      ],
    },
    {
      key: 'investments',
      type: 'repeat',
      wrappers: ['panel'],
      templateOptions: {
        addText: 'Add another investment',
        label: 'Investments To Track',
        style: {
          margin: '25px 0 0 0',
          border: 'solid 2px green'
        }
      },
      fieldArray: {
        fieldGroup: [
          {
            className: 'col-sm-4',
            type: 'input',
            key: 'investmentName',
            templateOptions: {
              label: 'Name of Investment:',
              required: true,
            },
          },
          {
            type: 'input',
            key: 'investmentDate',
            className: 'col-sm-4',
            templateOptions: {
              type: 'date',
              label: 'Date of Investment:',
            },
          },
          {
            type: 'input',
            key: 'stockIdentifier',
            className: 'col-sm-4',
            templateOptions: {
              label: 'Stock Identifier:',
            },
          },
        ],
      },
    },
  ];

  onSubmit() {
    //alert(
    //  JSON.stringify(this.model, null, 4)
    //);

    console.log(this.model);

  }
}
