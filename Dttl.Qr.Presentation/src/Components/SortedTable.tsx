import React from 'react';
import { MouseEventHandler, useCallback, useState, useEffect } from "react";
import data from "../data.json";
import { DefaultTemplateProps, TemplateList } from "../Props/TemplateProps";
import { getQrTemplateList } from '../Services/QrTemplate';

type Data = typeof data;

type SortKeys = keyof Data[0];

type SortOrder = "ascn" | "desc";

function sortData({
    tableData,
    sortKey,
    reverse,
}: {
    tableData: Data;
    sortKey: SortKeys;
    reverse: boolean;
}) {
    if (!sortKey) return tableData;

    const sortedData = data.sort((a, b) => {
        return a[sortKey] > b[sortKey] ? 1 : -1;
    });

    if (reverse) {
        return sortedData.reverse();
    }

    return sortedData;
}

function SortButton({
    sortOrder,
    columnKey,
    sortKey,
    onClick,
}: {
    sortOrder: SortOrder;
    columnKey: SortKeys;
    sortKey: SortKeys;
    onClick: MouseEventHandler<HTMLButtonElement>;
}) {
    return (
        <button
            onClick={onClick}
            className={`${sortKey === columnKey && sortOrder === "desc"
                ? "sort-button sort-reverse"
                : "sort-button"
                }`}
        >
            ▲
        </button>
    );
}

const SortableTable = ({ data }: { data: Data }) => {
    const [sortKey, setSortKey] = useState<SortKeys>("templateId");
    const [sortOrder, setSortOrder] = useState<SortOrder>("ascn");
        const [showTable, setShowTable] = useState(false);
        

    const headers: { key: SortKeys; label: string }[] = [
        { key: "templateId", label: "Template Id" },
        { key: "templateName", label: "Template Name" },
        { key: "height", label: "Height" },
        { key: "width", label: "Width" },
        { key: "foreColor", label: "Fore Color" },
        { key: "backgroundColor", label: "Background color" },
        { key: "logo", label: "logo" },
        { key: "isActive", label: "Is Active" },
        { key: "isApproved", label: "Is Approved" },
        { key: "createdBy", label: "created by" },
        { key: "createdDate", label: "craeted date" },
        { key: "modifiedBy", label: "modified by" },
        { key: "modifiedDate", label: "modified date" },
    ];

    const sortedData = useCallback(
        () => sortData({ tableData: data, sortKey, reverse: sortOrder === "desc" }),
        [data, sortKey, sortOrder]
    );

    function changeSort(key: SortKeys) {
        setSortOrder(sortOrder === "ascn" ? "desc" : "ascn");

        setSortKey(key);
        }

        const getTemplateTable = () => {
            
          
                getQrTemplateList(data)
                    .then(function (response) {
                        console.log(response);
                    })
                    .catch(function (error) {
                        console.log(error);
                    })
           
        }

   
        return (
            <>
                <button onClick={getTemplateTable}>list api status</button>

                <button onClick={() => { setShowTable(true) }} disabled={showTable}> List View </button>
                
         
         
           {
            showTable && <><table>
                <thead>
                    <tr>
                        {headers.map((row) => {
                            return (
                                <td key={row.key}>
                                    {row.label}{" "}
                                    <SortButton
                                        columnKey={row.key}
                                        onClick={() => changeSort(row.key)}
                                        {...{
                                            sortOrder,
                                            sortKey,
                                        }}
                                    />
                                </td>
                            );
                        })}
                    </tr>
                </thead>

                <tbody>
                    {sortedData().map((templateList) => {
                        return (
                            <tr key={templateList.templateId}>
                                <td>{templateList.templateId}</td>
                                <td>{templateList.templateName}</td>
                                <td>{templateList.height}</td>
                                <td>{templateList.width}</td>
                                <td>{templateList.foreColor}</td>
                                <td>{templateList.backgroundColor}</td>
                                <td><img src={templateList.logo}></img></td>
                                <td>{templateList.isActive}</td>
                                <td>{templateList.isApproved}</td>
                                <td>{templateList.createdBy}</td>
                                <td>{templateList.createdDate}</td>
                                <td>{templateList.modifiedBy}</td>
                                <td>{templateList.modifiedDate}</td>
                              
                            </tr>
                        );
                    })}
                </tbody>
            </table></> 
        }
        
            
        
            </>      );
               
}

export default SortableTable;