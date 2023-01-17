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

export const SortableTable = ({ data }: { data: Data }) => {
    const [sortKey, setSortKey] = useState<SortKeys>("templateId");
    const [sortOrder, setSortOrder] = useState<SortOrder>("ascn");
    const [showTable, setShowTable] = useState(false);
    const [search, setSearch] = useState("");
    const [template, setTemplate] = useState(data);

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
    {
        template.filter(item => {
            if (search == "") {
                return item
            }
            else if (item.templateName.toLowerCase().includes(search.toLowerCase())) {
                return item;
            }
        })
    }
    const handleSearch = () => {
        return (
            sortedData().filter(item =>
                item.templateName.toLowerCase().includes(search.toLowerCase()) || item.templateId.toString().includes(search.toLowerCase()) || item.height.toString().includes(search.toLowerCase()) || item.width.toString().includes(search.toLowerCase()) || item.foreColor.toString().includes(search.toLowerCase()) || item.backgroundColor.toString().includes(search.toLowerCase()) || item.logo.toString().includes(search.toLowerCase()) || item.isActive.toString().includes(search.toLowerCase()) || item.isApproved.toString().includes(search.toLowerCase()) || item.createdBy.toString().includes(search.toLowerCase()) || item.createdDate.toString().includes(search.toLowerCase()) || item.width.toString().includes(search.toLowerCase()) || item.createdDate.toString().includes(search.toLowerCase()) || item.modifiedBy.toString().includes(search.toLowerCase()) || item.modifiedDate.toString().includes(search.toLowerCase())
            )
        )
    }

    console.log(sortedData())
    let searchedData = search ? handleSearch() : sortedData();

    return (
        <>
            <button onClick={() => { setShowTable(true) }} disabled={showTable}> List Template</button>

            {showTable && <><input
                type="text"
                placeholder="Search here"
                onChange={(e) => {
                    setSearch(e.target.value);
                }} /><table>
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
                                            }} />
                                    </td>
                                );
                            })}
                        </tr>
                    </thead>

                    <tbody>
                        {searchedData.map((templateList) => {
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
        </>
    );
}