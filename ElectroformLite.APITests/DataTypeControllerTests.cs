using AutoMapper;
using ElectroformLite.API.Controllers;
using ElectroformLite.API.Dto;
using ElectroformLite.Application.DataTypes.Commands.CreateDataType;
using ElectroformLite.Application.DataTypes.Commands.DeleteDataType;
using ElectroformLite.Application.DataTypes.Commands.EditDataType;
using ElectroformLite.Application.DataTypes.Queries.GetDataType;
using ElectroformLite.Application.DataTypes.Queries.GetDataTypes;
using ElectroformLite.Domain.Models;
using MediatR;
using Moq;

namespace ElectroformLite.APITests;

public class DataTypeControllerTests
{
    private readonly Mock<IMediator> _mockMediator = new();
    private readonly Mock<IMapper> _mockMapper = new();

    [Fact]
    public async void GetDataTypes_GetDataTypesQuery_IsCalled()
    {
        // Arrange
        _mockMediator.Setup(m => m.Send(It.IsAny<GetDataTypesQuery>(), It.IsAny<CancellationToken>())).Verifiable();
        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        await controller.GetDataTypes();

        // Assert
        _mockMediator.Verify(m => m.Send(It.IsAny<GetDataTypesQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void GetDataType_GetDataTypeQuery_IsCalled()
    {
        // Arrange
        _mockMediator.Setup(m => m.Send(It.IsAny<GetDataTypeQuery>(), It.IsAny<CancellationToken>())).Verifiable();
        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        await controller.GetDataType(Guid.Empty);

        // Assert
        _mockMediator.Verify(m => m.Send(It.IsAny<GetDataTypeQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void CreateDataType_CreateDataTypeCommand_IsCalled()
    {
        // Arrange
        _mockMediator.Setup(m => m.Send(It.IsAny<CreateDataTypeCommand>(), It.IsAny<CancellationToken>())).Verifiable();
        _mockMapper.Setup(m => m.Map<DataTypeDto>(It.IsAny<DataType>())).Returns(new DataTypeDto());
        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        await controller.CreateDataType("Type");

        // Assert
        _mockMediator.Verify(m => m.Send(It.IsAny<CreateDataTypeCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void DeleteDataType_DeleteDataTypeCommand_IsCalled()
    {
        // Arrange
        _mockMediator.Setup(m => m.Send(It.IsAny<DeleteDataTypeCommand>(), It.IsAny<CancellationToken>())).Verifiable();
        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        await controller.DeleteDataType(Guid.Empty);

        // Assert
        _mockMediator.Verify(m => m.Send(It.IsAny<DeleteDataTypeCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async void UpdateDataType_EditDataTypeCommand_IsCalled()
    {
        // Arrange
        _mockMediator.Setup(m => m.Send(It.IsAny<EditDataTypeCommand>(), It.IsAny<CancellationToken>())).Verifiable();
        _mockMapper.Setup(m => m.Map<DataTypeDto>(It.IsAny<DataType>())).Returns(new DataTypeDto());
        DataTypesController controller = new(_mockMediator.Object, _mockMapper.Object);

        // Act
        await controller.UpdateDataType(Guid.Empty, new DataTypeDto());

        // Assert
        _mockMediator.Verify(m => m.Send(It.IsAny<EditDataTypeCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}