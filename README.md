## Dummy Data Adapter

This is a data adapter template project in WPF made for Electron Dashboard. Know more about Data Adapters for Electron Dashboard [here](https://github.com/nagasudhirpulla/electron_react_dashboard/wiki/Data-Adapters).

You can use this template project as a starting point to create a custom data adapter for Electron Dashboard


The folder DummyDataAdapterPlugin can be added to electron dashboard. 

It is created by copying the contents of bin/Debug folder and adding manifest.json file to the folder. The manifest.json file used in the folder is as shown below
```json
{
    "entry": "ElectronDashboardDummyDataAdapter.exe",
    "name": "DummyData",
    "app_id": "DummyDataAdapter",
    "out_types": ["timeseries"],
    "single_meas": true,
    "multi_meas": false,
    "quality_option": true,
    "is_meas_picker_present": true,
    "is_adapter_config_ui_present": true
}
```
