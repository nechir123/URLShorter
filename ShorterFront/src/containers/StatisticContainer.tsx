import { useEffect, useState } from "react";
import notify from "devextreme/ui/notify";
import DataGrid, { Button, Column, Editing } from "devextreme-react/data-grid";

function StatisticContainer() {
  const [data, setData] = useState([]);

  async function getData() {
    var loc = document.location;
    let code = loc.href.split("/").pop();
    const response = await fetch("/url/all/?code=" + code);
    const data = await response.json();
    setData(data);
  }
  useEffect(() => {
    getData();
  }, []);

  async function deleteUrl(urlId: string) {
    const response = await fetch("/url/?urlId=" + urlId, {
      method: "DELETE",
    });
    const data = await response.json();
    if (data.success) {
      notify("Url has been deleted", "success");
      getData();
    }
  }

  function validateRemove(e: any) {
    deleteUrl(e.data.urlId);
  }

  return (
    <div className="App">
      <header
        className="App-header"
        style={{ marginLeft: "100px", marginRight: "100px" }}
      >
        <DataGrid
          dataSource={data}
          showBorders={true}
          onRowRemoving={validateRemove}
        >
          <Editing
            mode="row"
            useIcons={true}
            allowUpdating={false}
            allowDeleting={true}
          />
          <Column type="buttons" width={110}>
            <Button name="edit" />
            <Button name="delete" />
          </Column>
          <Column
            dataField="clickDate"
            dataType="date"
            format="dd-MM-yyyy HH:mm:ss"
          />
          <Column dataField="shortenUrl" />
          
          <Column dataField="originalUrl" />
        </DataGrid>
      </header>
    </div>
  );
}

export default StatisticContainer;
